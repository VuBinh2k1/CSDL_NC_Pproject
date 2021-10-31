USE [QLHoaDon]
GO
-- 1. Danh sách các hoá đơn lập trong năm 2020
-- No Index / SCAN
SELECT *
FROM HoaDon
WHERE YEAR(NgayLap) = '2020'

-- Index / SEEK

-- 2. Danh sách các khách hàng ở TPHCM
-- No Index / SCAN
SELECT *
FROM KhachHang
WHERE TPho = N'Hồ Chí Minh'

-- Index

-- 3. Cho danh sách các sản phẩm có giá trong một khoảng từ....đến
-- Từ 1tr đến 5tr
-- No Index / SCAN
SELECT *
FROM SanPham
WHERE Gia BETWEEN 1000000 AND 5000000

-- Index

-- 4. Cho danh sách các sản phẩm có số lượng tồn < 100
-- No Index / SCAN
SELECT *
FROM SanPham
WHERE SoLuongTon < 100

-- Index

-- 5. Cho danh sách sản phẩm bán chạy nhất (số lượng bán nhiều nhất)
-- No Index / SCAN
SELECT TOP(1) CT.MaSP, SP.TenSP, SUM(CT.SoLuong) AS SL
FROM CT_HoaDon CT, SanPham SP
WHERE CT.MaSP = SP.MaSP
GROUP BY CT.MaSP, SP.TenSP
ORDER BY SUM(CT.SoLuong) DESC

-- Index

-- 6. Cho danh sách các sản phẩm có doanh thu cao nhất
-- No Index / SCAN
SELECT TOP(1) CT.MaSP, SP.TenSP, SUM(CT.ThanhTien) AS 'Doanh thu'
FROM CT_HoaDon CT, SanPham SP
WHERE CT.MaSP = SP.MaSP
GROUP BY CT.MaSP, SP.TenSP
ORDER BY SUM(CT.ThanhTien) DESC

-- Index

