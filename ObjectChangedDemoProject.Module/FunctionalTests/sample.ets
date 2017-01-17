;#DropDB ObjectChangedDemoProjectEasyTest

#Application ObjectChangedDemoProject.Win
#Application ObjectChangedDemoProject.Web
#IfDef ObjectChangedDemoProject.Win

*Action About...
 
*Action OK

#EndIf

#IfDef ObjectChangedDemoProject.Web
!Action Navigation(My Details)
#EndIf
