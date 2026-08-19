param(
    [Parameter(Mandatory = $true)]
    [string]$Owner,

    [Parameter(Mandatory = $true)]
    [string]$Repo
)

$ErrorActionPreference = 'Stop'

function Ensure-Gh {
    if (-not (Get-Command gh -ErrorAction SilentlyContinue)) {
        throw "GitHub CLI (gh) no está instalado. Instálalo desde https://cli.github.com/"
    }
}

function New-LabelIfMissing {
    param(
        [string]$Name,
        [string]$Color,
        [string]$Description
    )

    $existing = gh label list --repo "$Owner/$Repo" --limit 500 --json name | ConvertFrom-Json
    if ($existing.name -contains $Name) {
        Write-Host "Label ya existe: $Name"
        return
    }

    gh label create $Name --repo "$Owner/$Repo" --color $Color --description $Description | Out-Null
    Write-Host "Label creado: $Name"
}

function New-MilestoneIfMissing {
    param(
        [string]$Title,
        [string]$Description
    )

    $existing = gh api "repos/$Owner/$Repo/milestones?state=all&per_page=100" | ConvertFrom-Json
    if ($existing.title -contains $Title) {
        Write-Host "Milestone ya existe: $Title"
        return
    }

    gh api "repos/$Owner/$Repo/milestones" --method POST --field title="$Title" --field description="$Description" | Out-Null
    Write-Host "Milestone creado: $Title"
}

Ensure-Gh

$labels = @(
    @{ Name = 'type:user-story';      Color = '1D76DB'; Description = 'Historia de usuario' },
    @{ Name = 'type:epic';            Color = '5319E7'; Description = 'Épica funcional' },
    @{ Name = 'type:task';            Color = '0052CC'; Description = 'Tarea técnica' },
    @{ Name = 'type:bug';             Color = 'D73A4A'; Description = 'Bug o defecto' },
    @{ Name = 'type:spike';           Color = 'FBCA04'; Description = 'Investigación' },

    @{ Name = 'scope:alcance-1';      Color = '0E8A16'; Description = 'Módulo presupuesto' },
    @{ Name = 'scope:alcance-2';      Color = '006B75'; Description = 'Módulo tareas' },

    @{ Name = 'priority:must-have';   Color = 'B60205'; Description = 'Prioridad máxima' },
    @{ Name = 'priority:should-have'; Color = 'D93F0B'; Description = 'Prioridad importante' },
    @{ Name = 'priority:could-have';  Color = 'FBCA04'; Description = 'Prioridad deseable' },

    @{ Name = 'status:todo';          Color = 'C2E0C6'; Description = 'Pendiente' },
    @{ Name = 'status:ready';         Color = '0E8A16'; Description = 'Lista para desarrollo' },
    @{ Name = 'status:in-progress';   Color = '1D76DB'; Description = 'En desarrollo' },
    @{ Name = 'status:blocked';       Color = 'B60205'; Description = 'Bloqueada' },
    @{ Name = 'status:done';          Color = '5319E7'; Description = 'Terminada' },

    @{ Name = 'sprint:1';             Color = 'E4E669'; Description = 'Sprint 1' },
    @{ Name = 'sprint:2';             Color = 'E4E669'; Description = 'Sprint 2' },
    @{ Name = 'sprint:3';             Color = 'E4E669'; Description = 'Sprint 3' },
    @{ Name = 'sprint:4';             Color = 'E4E669'; Description = 'Sprint 4' },
    @{ Name = 'sprint:5';             Color = 'E4E669'; Description = 'Sprint 5' },
    @{ Name = 'sprint:6';             Color = 'E4E669'; Description = 'Sprint 6' },
    @{ Name = 'sprint:7';             Color = 'E4E669'; Description = 'Sprint 7' },
    @{ Name = 'sprint:8';             Color = 'E4E669'; Description = 'Sprint 8' },
    @{ Name = 'sprint:9';             Color = 'E4E669'; Description = 'Sprint 9' },

    @{ Name = 'area:identity';        Color = 'C5DEF5'; Description = 'Autenticación y cuenta' },
    @{ Name = 'area:dashboard';       Color = 'C5DEF5'; Description = 'Dashboard' },
    @{ Name = 'area:budget';          Color = 'C5DEF5'; Description = 'Presupuesto y transacciones' },
    @{ Name = 'area:sync';            Color = 'C5DEF5'; Description = 'Offline y sincronización' },
    @{ Name = 'area:tasks';           Color = 'C5DEF5'; Description = 'Tareas' },
    @{ Name = 'area:notifications';   Color = 'C5DEF5'; Description = 'Alertas y recordatorios' },
    @{ Name = 'area:reports';         Color = 'C5DEF5'; Description = 'Reportes y exportación' }
)

$milestones = @(
    @{ Title = 'Sprint 1 - Auth + Offline'; Description = 'Registro, login, logout, offline-first' },
    @{ Title = 'Sprint 2 - Dashboard + CRUD Transacciones'; Description = 'Dashboard y CRUD principal de transacciones' },
    @{ Title = 'Sprint 3 - Lista, Filtros y Categorías'; Description = 'Filtros, detalle y categorías' },
    @{ Title = 'Sprint 4 - Presupuesto y Alertas'; Description = 'Metas, períodos y alertas' },
    @{ Title = 'Sprint 5 - Recurrentes + Gráficas'; Description = 'Recurrentes y visualización por categoría' },
    @{ Title = 'Sprint 6 - Reportes + Monedas'; Description = 'Exportación, evolución y multimoneda' },
    @{ Title = 'Sprint 7 - Tareas Núcleo'; Description = 'CRUD base de tareas' },
    @{ Title = 'Sprint 8 - Subtareas + Recordatorios'; Description = 'Subtareas, recordatorios y detalle' },
    @{ Title = 'Sprint 9 - Calendario + Personalización'; Description = 'Calendario y prioridades personalizadas' }
)

foreach ($label in $labels) {
    New-LabelIfMissing -Name $label.Name -Color $label.Color -Description $label.Description
}

foreach ($milestone in $milestones) {
    New-MilestoneIfMissing -Title $milestone.Title -Description $milestone.Description
}

Write-Host "Configuración de labels y milestones finalizada."
