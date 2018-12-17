-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Alexander Nygård
-- Create date: 17.12.2018
-- Description:	Finner kvoter pr ansatt
-- =============================================
CREATE PROCEDURE FinneKvoter 
	-- Add the parameters for the stored procedure here
	@Ansattnummer FLOAT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
	dbo.tbl_kundeliste_med_forskjellige_nummer.Ansattnr, dbo.tbl_kundeliste_med_forskjellige_nummer.T0E, 
	dbo.tbl_kundeliste_med_forskjellige_nummer.[T0E Navn], 
	dbo.tbl_kundeliste_med_forskjellige_nummer.Fornavn, 
	dbo.tbl_kundeliste_med_forskjellige_nummer.Etternavn,
	dbo.[Tbl_Kvotefiler fra Zalaris].Oppdatert_dato,
	dbo.[Tbl_kvotefiler fra Zalaris].Salgs_dato,
	dbo.[Tbl_Kvotefiler fra Zalaris].Kvotekode, 
	dbo.[Tbl_Kvotefiler fra Zalaris].Materialnummer, 
	dbo.Tbl_Material_master.Tekst,
	dbo.[Tbl_Kvotefiler fra Zalaris].Øl, 
	dbo.[Tbl_Kvotefiler fra Zalaris].Brus, 
	dbo.[Tbl_Kvotefiler fra Zalaris].Gratis,
	dbo.Tbl_Kvotedefinisjoner.Øl,
	dbo.Tbl_Kvotedefinisjoner.Brus,
	dbo.Tbl_Kvotedefinisjoner.Gratis
	FROM dbo.tbl_kundeliste_med_forskjellige_nummer 
	INNER JOIN dbo.[Tbl_kvotefiler fra Zalaris] 
	ON dbo.tbl_kundeliste_med_forskjellige_nummer.Ansattnr = dbo.[Tbl_kvotefiler fra Zalaris].Ansattnummer 
	LEFT JOIN dbo.Tbl_Kvotedefinisjoner 
	ON dbo.[Tbl_Kvotefiler fra Zalaris].Kvotekode = dbo.Tbl_Kvotedefinisjoner.Kvote
	LEFT JOIN dbo.Tbl_Material_Master
	ON dbo.[Tbl_Kvotefiler fra Zalaris].Materialnummer = dbo.Tbl_Material_Master.BSP1
	WHERE Ansattnr = @Ansattnummer;
	
END
GO
