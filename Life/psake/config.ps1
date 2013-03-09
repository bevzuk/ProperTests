Framework '4.0'

properties {
	$configuration = 'Debug'

	$solutionPath = '../'
	$solutionFilename = $solutionPath + 'Life.sln'

	$migrationsPath = $solutionPath + 'Tests/ApplicationTests'
    $migrationsDllName = 'ApplicationTests'
    $migratorPath = $solutionPath + 'packages/Migrator.1.1/tools'
	
    $migrator = (Get-Item "$migratorPath/Migrator.Console.exe")
}

task default -depends DoNotRunItDirectly

task DoNotRunItDirectly {
	'Do not run it directly!'
}

task Build {
	MSBuild -t:Build -p:Configuration=$configuration $solutionFilename
}

task Migrate {
#	Invoke-Expression "$migrator --provider=sqlserver --connectionString=Main --target=$migrationsPath/$migrationsDllName.dll"
	MSBuild -t:Migrate $migrationsPath/$migrationsDllName.proj
}
