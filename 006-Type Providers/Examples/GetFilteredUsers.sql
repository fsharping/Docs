SELECT u.Name, u.Surname, u.Age 
FROM FSharping.[dbo].Users u
WHERE u.Surname LIKE '%' + @Surname + '%'