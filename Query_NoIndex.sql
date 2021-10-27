USE [QLHoaDon]
GO
-- 1. Danh sách các hoá đơn lập trong năm 2020
SELECT *
FROM HoaDon
WHERE YEAR(NgayLap) = '2020'

-- 2. Danh sách các khách hàng ở TPHCM
SELECT *
FROM KhachHang
WHERE TPho = N'Hồ Chí Minh'