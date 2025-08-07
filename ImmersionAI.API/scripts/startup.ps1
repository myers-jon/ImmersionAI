# scripts/startup.ps1
$ErrorActionPreference = 'Stop'

$max = 10; $delay = 3
Write-Host "⏳ Waiting for Ollama API at http://localhost:11434..."
for ($i = 1; $i -le $max; $i++) {
    try {
        Invoke-RestMethod -Uri "http://localhost:11434/api/generate" `
            -Method POST `
            -Body (@{ prompt = "health check" } | ConvertTo-Json) `
            -ContentType "application/json" | Out-Null
        Write-Host "✅ Ollama is ready."
        break
    }
    catch {
        if ($i -eq $max) { throw "Ollama did not respond after $max attempts." }
        Write-Host "🚧 Attempt $i failed, retrying in $delay s..."
        Start-Sleep -Seconds $delay
    }
}

Write-Host "🚀 Preloading DeepSeek model..."
Invoke-RestMethod -Uri "http://localhost:11434/api/models/load" `
    -Method POST `
    -Body (@{ model = "deepseek" } | ConvertTo-Json) `
    -ContentType "application/json" | Out-Null

Write-Host "🚀 Launching ImmersionAI.API"
dotnet ImmersionAI.API.dll
