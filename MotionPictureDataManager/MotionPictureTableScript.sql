
CREATE TABLE MotionPictures
(id int NOT NULL identity(1,1),
name nvarchar(50) NOT NULL,
description nvarchar(500) null,
release_year int NOT NULL,

constraint pk_motion_pictures PRIMARY KEY (id)
)

INSERT INTO [dbo].[MotionPictures]
           (
           [name]
           ,[description]
           ,[release_year])
     VALUES
           (
           'Blast To The Past'
           ,'Similar to "Back to the Future"'
           ,2022)

INSERT INTO dbo.MotionPictures VALUES
('Horrifying Movie', 'An even scarier movie',2017);
SELECT SCOPE_IDENTITY();

INSERT INTO dbo.MotionPictures VALUES
('Razor Sprinter', 'Live life on the edge', 2026),
('Hard Knock Life', 'A spin-off for the orphans', 1977);