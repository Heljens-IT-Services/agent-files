// Erzeugt Backend- und Frontend-Code aus contracts/api.yaml mit OpenAPI Generator.
// Aufruf aus dem Repository-Root: node scripts/generate-api.mjs [--check]
// Mit --check schlägt der Lauf fehl, wenn der erzeugte Code vom committeten Stand abweicht.
// Generatorversion und Optionen stehen in openapitools.json; benötigt Node und Java 11 oder neuer.
import { execFileSync } from 'node:child_process';
import { cpSync, readdirSync, rmSync } from 'node:fs';
import { join, relative, resolve } from 'node:path';

const root = resolve(import.meta.dirname, '..');
const frontendDir = join(root, 'app/frontend');
const tempDir = join(root, '.openapi-generator-tmp');

// Ziele der erzeugten Dateien; beide Verzeichnisse gehören ausschließlich dem Generator.
const backendTarget = join(root, 'backend/src/WebApi/Contracts/Generated');
const frontendTarget = join(frontendDir, 'src/app/core/data-access/api/generated');
const backendPackage = 'Example.WebApi.Contracts.Generated';

// Generatorausgaben auf oberster Ebene, die nicht ins Repository gehören.
const excludedEntries = new Set(['.gitignore', '.openapi-generator', '.openapi-generator-ignore', 'README.md', 'git_push.sh']);

function generate(generatorKey) {
  const cli = join(frontendDir, 'node_modules/.bin/openapi-generator-cli');
  execFileSync(process.platform === 'win32' ? `${cli}.cmd` : cli, ['generate', '--generator-key', generatorKey], {
    cwd: root,
    // Die CLI liest ihr Arbeitsverzeichnis aus PWD bzw. INIT_CWD; über npm gestartet zeigen beide
    // sonst auf app/frontend, und #{cwd} sowie openapitools.json würden dort aufgelöst.
    env: { ...process.env, PWD: root, INIT_CWD: root },
    stdio: 'inherit',
    shell: process.platform === 'win32',
  });
}

function replaceDirectory(target, source) {
  const isWanted = (path) => !excludedEntries.has(relative(source, path).split(/[\\/]/)[0]);
  rmSync(target, { recursive: true, force: true });
  cpSync(source, target, { recursive: true, filter: isWanted });
  removeEmptyDirectories(target);
}

// Der Backend-Generator legt Ordner für übersprungene Hilfsdateien leer an.
function removeEmptyDirectories(directory) {
  for (const entry of readdirSync(directory, { withFileTypes: true })) {
    if (entry.isDirectory()) {
      removeEmptyDirectories(join(directory, entry.name));
    }
  }
  if (readdirSync(directory).length === 0) {
    rmSync(directory, { recursive: true });
  }
}

rmSync(tempDir, { recursive: true, force: true });
try {
  generate('backend');
  generate('frontend');

  replaceDirectory(backendTarget, join(tempDir, 'backend', backendPackage));
  replaceDirectory(frontendTarget, join(tempDir, 'frontend'));
} finally {
  rmSync(tempDir, { recursive: true, force: true });
}

if (process.argv.includes('--check')) {
  // Erfasst geänderte, neue und gelöschte Dateien in beiden Zielverzeichnissen.
  const drift = execFileSync('git', ['status', '--porcelain', '--', backendTarget, frontendTarget], { cwd: root, encoding: 'utf8' });
  if (drift.trim().length > 0) {
    console.error(`Erzeugter Code weicht von contracts/api.yaml ab. node scripts/generate-api.mjs ausführen und committen:\n${drift}`);
    process.exit(1);
  }
}
