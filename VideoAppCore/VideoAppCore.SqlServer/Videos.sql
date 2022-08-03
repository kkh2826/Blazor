
-- 비디오 테이블
CREATE TABLE [dbo].[Videos]
(
	[Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Title] NVARCHAR(255) NOT NULL,	-- 제목
	[Url] NVARCHAR(MAX) NULL,		-- URL
	[Name] NVARCHAR(50) NULL,		-- 이름
	[Company] NVARCHAR(255) NULL,	-- 회사
	--[Created] Datetimeoffset(7) DEFAULT(SYSDATETIMEOFFSET() AT TIME ZONE 'Korea Standard Time'),
	[CreatedBy] NVARCHAR(255) NULL,
	[Created] DateTime Default(GetDate()),
	[ModifiedBy] NVARCHAR(255) NULL,
	[Modified] DateTime Null,
)
GO

