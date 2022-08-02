
-- 비디오 테이블
CREATE TABLE [dbo].[Videos]
(
	[Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Created] Datetimeoffset(7) DEFAULT(SYSDATETIMEOFFSET() AT TIME ZONE 'Korea Standard Time'),
	[Title] NVARCHAR(255) NOT NULL,	-- 제목
	[Url] NVARCHAR(MAX) NULL,		-- URL
	[Name] NVARCHAR(50) NULL,		-- 이름
	[Company] NVARCHAR(255) NULL,	-- 회사
)
GO

