CREATE VIEW Course_Credits AS

SELECT COURSENAME, CREDITS
FROM COURSE
WHERE CREDITS > 12;

/

SELECT *
FROM Course_Credits;