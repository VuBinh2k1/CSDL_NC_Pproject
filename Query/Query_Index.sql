USE [QLHoaDon]
GO

SET SHOWPLAN_TEXT OFF

-- 1. Danh sách các hoá đơn lập trong năm 2020

-- Create Index

CREATE NONCLUSTERED INDEX [IDX_NgayLap]
ON [dbo].[HoaDon] ([NgayLap])
INCLUDE ([MaKH],[TongTien])

-- Query
SELECT *
FROM HoaDon
WHERE NgayLap >= '2020-01-01' AND NgayLap <= '2020-12-31'

-- 5. Cho danh sách sản phẩm bán chạy nhất (số lượng bán nhiều nhất)

-- Create Index
CREATE NONCLUSTERED INDEX [IDX_MaSP_SL] 
ON CT_HoaDon(MaSP) INCLUDE (SoLuong)

-- Query
SELECT TOP(1) CT.MaSP, SP.TenSP, SUM(CT.SoLuong) AS SL
FROM CT_HoaDon CT, SanPham SP
WHERE CT.MaSP = SP.MaSP
GROUP BY CT.MaSP, SP.TenSP
ORDER BY SUM(CT.SoLuong) DESC

-- 6. Cho danh sách các sản phẩm có doanh thu cao nhất

-- Create Index
CREATE NONCLUSTERED INDEX [IDX_MaSP_TT] 
ON CT_HoaDon(MaSP) 
INCLUDE (ThanhTien)

-- Query
SELECT TOP(1) CT.MaSP, SP.TenSP, SUM(CT.ThanhTien) AS 'Doanh thu'
FROM CT_HoaDon CT, SanPham SP
WHERE CT.MaSP = SP.MaSP
GROUP BY CT.MaSP, SP.TenSP
ORDER BY SUM(CT.ThanhTien) DESC

-- Các truy vấn khác để so sánh
-- a.	Select * from A join B join C on... & Select * from A,B,C where A.x = B.x...

-- JOIN
SELECT *
FROM HoaDon AS HD 
JOIN CT_HoaDon AS CT ON HD.MaHD = CT.MaHD
JOIN SANPHAM AS SP ON CT.MaSP = SP.MaSP

-- SUBQUERY
SELECT *
FROM HoaDon AS HD, CT_HoaDon AS CT, SANPHAM AS SP 
WHERE HD.MaHD = CT.MaHD AND CT.MaSP = SP.MaSP

-- Select * from A join B (A có số dòng nhỏ, B rất lớn) & Select * from B join A

-- A nhỏ join B lớn
SELECT *
FROM HoaDon_Copy AS HD 
JOIN CT_HoaDon AS CT ON HD.MaHD = CT.MaHD

-- B lớn join A nhỏ
SELECT *
FROM CT_HoaDon AS CT
JOIN HoaDon_Copy AS HD ON HD.MaHD = CT.MaHD