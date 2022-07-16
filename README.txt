#Generar certificado local
dotnet dev-certs https
#Comando SQL
Scaffold-DbContext "Server=DESKTOP-552QF02;Database=Az204;User ID=UserAz204;Password=123456" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context "Az204Context" -DataAnnotations
