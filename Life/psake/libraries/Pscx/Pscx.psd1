@{
    GUID               = '0fab0d39-2f29-4e79-ab9a-fd750c66e6c5'
    Author             = 'PowerShell Community Developers'
    CompanyName        = 'http://pscx.codeplex.com/'
    Copyright          = 'Copyright PowerShell Community Developers 2006 - 2010.'
    Description        = 'PowerShell Community Extensions (PSCX) base module which implements a general purpose set of Cmdlets.'
    PowerShellVersion  = '2.0'
    CLRVersion         = '2.0'
    ModuleVersion      = '2.0.0.1'
    RequiredAssemblies = 'Pscx.dll' # needed for [pscxmodules] type (does not import cmdlets/providers)
    ModuleToProcess    = 'Pscx.psm1'
	NestedModules      = 'Pscx.dll'    
	CmdletsToExport    = '*'
    FormatsToProcess   = @(
        'FormatData\Pscx.Format.ps1xml',
        'FormatData\Pscx.FeedStore.Format.ps1xml',
        'FormatData\Pscx.Archive.Format.ps1xml',
        'FormatData\Pscx.Environment.Format.ps1xml',
        'FormatData\Pscx.Security.Format.ps1xml',
        'FormatData\Pscx.SIUnits.Format.ps1xml',
        'FormatData\Pscx.TerminalServices.Format.ps1xml'
    )
    TypesToProcess     = @(
        'TypeData\Pscx.FeedStore.Type.ps1xml',
        'TypeData\Pscx.Archive.Type.ps1xml',
        'TypeData\Pscx.Reflection.Type.ps1xml',
        'TypeData\Pscx.SIUnits.Type.ps1xml',
        'TypeData\Pscx.TerminalServices.Type.ps1xml',
        'TypeData\Pscx.Wmi.Type.ps1xml'
    )
}