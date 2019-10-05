--problem 1
SELECT COUNT(*) FROM WizzardDeposits

--problem 2
SELECT TOP(1) MagicWandSize AS [LongestMagicWand]  from WizzardDeposits order by MagicWandSize desc

--problem3
SELECT DepositGroup, Max(MagicWandSize) FROM WizzardDeposits GROUP BY
DepositGroup

--problem4
SELECT TOP(2) DepositGroup FROM WizzardDeposits group by DepositGroup order by AVG(MagicWandSize)

--problem5
SELECT DepositGroup, SUM(DepositAmount) FROM WizzardDeposits group by DepositGroup

--problem6
SELECT DepositGroup, SUM(DepositAmount) as TotalSum FROM WizzardDeposits where MagicWandCreator = 'Ollivander family' group by DepositGroup

--problem7
SELECT DepositGroup, SUM(DepositAmount) as TotalSum FROM WizzardDeposits where MagicWandCreator = 'Ollivander family' group by DepositGroup having SUM(DepositAmount) < 150000 order by SUM(DepositAmount) desc

--problem8
SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) FROM WizzardDeposits group by DepositGroup, MagicWandCreator order by MagicWandCreator, DepositGroup

--problem9
SELECT Groups.AgeGroups, COUNT(Groups.AgeGroups) FROM (SELECT case
    when Age BETWEEN 0 and 10 then '[0-10]'
    when Age between 11 and 20 then '[11-20]'
    when Age between  21 and 30 then '[21-30]'
    when age between 31 and 40 then '[31-40]'
    when age between 41 and 50 then '[41-50]'
    when age between 51 and 60 then '[51-60]'
    else '[61+]'
END AS [AgeGroups] FROM WizzardDeposits) AS [Groups] group by Groups.AgeGroups

--problem10
SELECT LEFT(FirstName, 1)
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
group by LEFT(FirstName, 1)

--problem11
SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '01/01/1985'
group by DepositGroup, IsDepositExpired
order by DepositGroup desc, IsDepositExpired

--problem12
SELECT SUM(k.diff) FROM
(SELECT wz.DepositAmount - (SELECT DepositAmount from WizzardDeposits as w where w.Id = wz.Id + 1) as diff FROM WizzardDeposits as wz) as k

--problem15
SELECT * INTO NewEmployeeTable from Employees where Salary > 30000
DELETE from NewEmployeeTable where ManagerID in(42)
UPDATE NewEmployeeTable set Salary += 5000 where DepartmentID = 1
SELECT DepartmentID, AVG(Salary) FROM NewEmployeeTable group by DepartmentID

--problem16
SELECT DepartmentID, MAX(Salary) from Employees group by DepartmentID having MAX(Salary) NOT BETWEEN 30000 and 70000

--problem17
SELECT COUNT(Salary) AS Count from Employees where ManagerID IS NULL

--problem18
SELECT RankedTable.DepartmentID, RankedTable.Salary FROM
(SELECT DepartmentID, Salary, DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS [Rank]
    FROM Employees
GROUP BY DepartmentID, Salary) AS [RankedTable]
where Rank = 3

--problem19
SELECT top(10) FirstName, LastName, DepartmentID from Employees em where Salary > (SELECT AVG(Salary) from Employees e where e.DepartmentID = em.DepartmentID) order by DepartmentID
