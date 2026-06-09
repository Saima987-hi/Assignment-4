use ToDoList
CREATE TABLE TodoItems (
    Id          INT           PRIMARY KEY IDENTITY(1,1),
    Task        NVARCHAR(500) NOT NULL,
    IsCompleted INT           NOT NULL DEFAULT 0,
    CreatedAt   NVARCHAR(100) NOT NULL
);
SELECT*FROM TodoItems
