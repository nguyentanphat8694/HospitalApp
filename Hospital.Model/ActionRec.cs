using System;
namespace Hospital.App
{
	[Serializable]
	public enum ActionRec
	{
		None,
		Insert,
		Delete,
		Update,
		Enable,
		Disable
	}
    [Serializable]
    public enum etrangthai
    {
        Đang_điều_trị,
        Hoàn_thành,
        Đã_hủy,
        Đang_chờ,
        Chưa_thu,
        Đã_thu,
        Chờ_duyệt,
        Đã_duyệt,
        Chưa_đến,
        Đã_đến,
        Quá_hẹn,
        Đã_hạch_toán,
        Điều_chỉnh,
    }
    public enum ePhanquyen
    {
        Admin,
        Đăng_ký,
        Tiếp_nhận,
        Thu_tiền,
        Siêu_Âm,
        Nhập_Kho,
        Xét_Nghiệm,
        Design_report,
    }
    public enum eLoaiphacdo
    {
        Phác_đồ_chỉ_định,
        Phác_đồ_thuốc,
    }
    public enum eLoaiPhieuTH
    {
        None,
        Kham_Benh,
        Sieu_Am,
        Xet_Nghiem,
        CLS,
        XNNT,
    }

    public enum eTableName
    {
        Customer,
        Design,
        DMDichVu,
        DMNhomDichVu,
        DMDonVi,
        DMICD,
        DMKho,
        DMLK,
        DMMau,
        DMNhanSu,
        DMPK,
        DMTSo,
        Record,
        User,
        ChiDinh,
        CTChiDinh,
        BenhAn,
        PhieuThu,
        DMThuoc,
        CDHA,
        DMXetNghiem,
        DMNhomXetNghiem,
        PhieuXetNghiem,
        PhacDo,
        DMQuan,
        DMTinh,
        TKBenhNhan,
        DMNgheNghiep,
    }

    public enum eLoaiHH {
        Thuốc,
        Dịch_vụ
    }

    public enum eLoaiNS
    {
        Bác_sĩ,
        Điều_dưỡng,
    }

    public enum eKhamBenh
    {
        AmHo,
        AmDao,
        CoTuCung,
        PhanPhu,
        CungDo,
        GoTuCung,
        Ngoi,
        Oi,
        KhungChau,
        GhiNhanKhac,
        LyDoKham,
        LSDiUng,
        LSNoiNgoaiKhoa,
        LSSanPhuKhoa,
        BenhSu
    }
}
