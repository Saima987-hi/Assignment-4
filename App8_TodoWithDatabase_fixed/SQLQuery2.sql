use ToDoDB;
-- 1. TABLE BANAO
CREATE TABLE TodoItems (
    Id          INT           PRIMARY KEY IDENTITY(1,1),
    Task        NVARCHAR(500) NOT NULL,
    IsCompleted INT           NOT NULL DEFAULT 0,
    CreatedAt   NVARCHAR(100) NOT NULL
);

-- 2. SAB ITEMS DEKHO
SELECT*FROM TodoItems
ORDER BY Id DESC;