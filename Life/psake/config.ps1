Framework '4.0'

properties {
	$configuration = 'Debug'

	$solutionPath = '../'
	$solutionFilename = $solutionPath + 'Life.sln'

	$dbScriptsPath = $solutionPath + 'DB/Scripts/'
	$migrator = $solutionPath + 'packages/dbmg.0.5.5.2/tools/dbmg.exe'
	$connectionString = "Data Source=.;Initial Catalog=Life;Integrated Security=True;MultipleActiveResultSets=True"
	$database = "mssql"
}

task default -depends DoNotRunItDirectly

task DoNotRunItDirectly {
	'Do not run it directly!'
}

task Build {
	MSBuild -t:Build -p:Configuration=$configuration $solutionFilename
}

task DB {
	Echo "$migrator -c ""$connectionString"" -d ""$dbScriptsPath"" -p $database"
	Invoke-Expression "$migrator -c ""$connectionString"" -d ""$dbScriptsPath"" -p $database"
}
