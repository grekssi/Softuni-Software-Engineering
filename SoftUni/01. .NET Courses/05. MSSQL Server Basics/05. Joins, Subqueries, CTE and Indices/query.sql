--problem1
SELECT TOP(5) e.EmployeeID,
       e.JobTitle,
       e.AddressID,
       a.AddressText
FROM Employees e join Addresses a on e.AddressID = A.AddressID
ORDER BY AddressID asc

--problem2
SELECT TOP(50)
        e.FirstName,
        e.LastName,
        t.Name,
        a.AddressText
FROM Employees e JOIN Addresses a on e.AddressID = A.AddressID
JOIN Towns t on a.TownID = t.TownID
ORDER BY FirstName asc, LastName

--problem3
SELECT EmployeeID,
       FirstName,
       LastName,
       d.Name
FROM Employees e join Departments d on e.DepartmentID = d.DepartmentID
WHERE d.Name in ('Sales')
ORDER BY EmployeeID asc

--problem4
SELECT TOP(5) EmployeeID,
       FirstName,
       Salary,
       d.Name
FROM Employees e join Departments d on e.DepartmentID = d.DepartmentID
WHERE e.Salary >= 15000
ORDER BY d.DepartmentID asc

--problem5
SELECT TOP(3) e.EmployeeID, e.FirstName
FROM Employees e FULL JOIN EmployeesProjects ep on e.EmployeeID = ep.EmployeeID
WHERE ep.ProjectID IS NULL

--problem6
SELECT FirstName,
       LastName,
       HireDate,
       D.Name
FROM Employees e join Departments D on e.DepartmentID = D.DepartmentID
Where D.Name in ('Sales', 'Finance') AND e.HireDate > '1999-01-01'
order by e.HireDate asc

--problem7
SELECT TOP(5) e.EmployeeID,
       e.FirstName,
       p.Name
FROM Employees e join EmployeesProjects EP on e.EmployeeID = EP.EmployeeID
join Projects P on EP.ProjectID = P.ProjectID
Where p.StartDate >= '2002.08.13' AND EndDate IS NULL
order by e.EmployeeID asc

--problem8
SELECT e.EmployeeID,
       e.FirstName,
        IIF(YEAR(p.StartDate) >= 2005, NULL, p.Name)
FROM Employees e full join EmployeesProjects EP on e.EmployeeID = EP.EmployeeID
FULL JOIN Projects P on EP.ProjectID = P.ProjectID
where EP.EmployeeID = 24

--problem9
SELECT e.EmployeeID, e.FirstName, e.ManagerID, mg.FirstName AS [ManagerName]
    FROM Employees AS e
    JOIN Employees AS mg ON mg.EmployeeID = e.ManagerID
   WHERE mg.EmployeeID IN (3, 7)
ORDER BY e.EmployeeID

--problem10
SELECT TOP(50) e.EmployeeID,
       (e.FirstName + ' ' + e.LastName) AS [EmployeeName],
       (m.FirstName + ' ' + m.LastName) AS [ManagerName],
       d.Name AS [DepartmentName]
FROM Employees e join Employees m on m.EmployeeID = e.ManagerID
JOIN Departments d ON e.DepartmentID = d.DepartmentID
order by EmployeeID

--problem11
SELECT TOP(1) AVG(Salary) AS [MinAverageSalary]
FROM Employees group by DepartmentID
order by MinAverageSalary

--problem12
SELECT c.CountryCode,
       M.MountainRange,
       P.PeakName,
       P.Elevation
FROM Countries c
    join MountainsCountries MC on c.CountryCode = MC.CountryCode
    join Mountains M on MC.MountainId = M.Id
    join Peaks P on M.Id = P.MountainId
WHERE c.CountryName = 'Bulgaria' AND p.Elevation > 2835
order by p.Elevation desc

--problem13
SELECT c.CountryCode,COUNT(m.MountainRange) FROM Countries c
join MountainsCountries MC on c.CountryCode = MC.CountryCode
join Mountains M on MC.MountainId = M.Id
WHERE c.CountryCode in('BG', 'RU', 'US')
group by c.CountryCode

--problem14
SELECT TOP(5) c.CountryName, r2.RiverName
FROM Countries c
FULL join CountriesRivers CR
    on cr.CountryCode = c.CountryCode
FULL JOIN Rivers R2
    on R2.Id = cr.RiverId
WHERE c.ContinentCode = 'AF'
order by CountryName

--problem15
 SELECT k.ContinentCode, k.CurrencyCode, k.CurrencyUsage
    FROM (
  SELECT c.ContinentCode,
         c.CurrencyCode,
  	     COUNT(c.CurrencyCode) AS [CurrencyUsage],
  	     DENSE_RANK() OVER(PARTITION BY c.ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) AS [Rank]
    FROM Countries AS c
    JOIN Currencies AS cc ON cc.CurrencyCode = c.CurrencyCode
GROUP BY c.ContinentCode, c.CurrencyCode
  HAVING COUNT(c.CurrencyCode) != 1) AS k
   WHERE k.[Rank] = 1
ORDER BY k.ContinentCode;

--problem16
    SELECT Count(*) as [Count] FROM Countries c
        full join MountainsCountries MC
            on MC.CountryCode = c.CountryCode
    WHERE mc.MountainId IS NULL

--problem17
SELECT TOP(5) CountryName, MAX(Elevation) AS [HighestPeakElevation]
     , MAX(Length) AS [LongestRiverLength]
FROM Countries c
full join MountainsCountries MC on c.CountryCode = MC.CountryCode
full join Mountains M on MC.MountainId = M.Id
full join Peaks P on M.Id = P.MountainId
full join CountriesRivers CR on c.CountryCode = CR.CountryCode
full join Rivers R2 on CR.RiverId = R2.Id
group by CountryName
order by MAX(Elevation) desc, MAX(Length) desc, CountryName asc

--problem18
 SELECT TOP(5) k.CountryName,
          ISNULL(k.PeakName, '(no highest peak)'),
		  ISNULL(k.[Highest Peak Elevation], 0),
		  ISNULL(k.MountainRange, '(no mountain)')
     FROM (
   SELECT c.CountryName,
          p.PeakName,
		  MAX(p.Elevation) AS [Highest Peak Elevation],
		  m.MountainRange,
		  DENSE_RANK() OVER(PARTITION BY c.CountryName ORDER BY MAX(p.Elevation) DESC) AS [Rank]
     FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
LEFT JOIN Peaks AS p ON p.MountainId = mc.MountainId
 GROUP BY c.CountryName, p.PeakName, m.MountainRange) AS k
    WHERE k.[Rank] = 1
 ORDER BY k.CountryName, k.PeakName;





