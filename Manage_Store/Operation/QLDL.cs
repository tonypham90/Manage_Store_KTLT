using Manage_Store.DAL;
using Manage_Store.Entity;

namespace Manage_Store.Operation;

public class QLDL
{

    public List<LoaiHang>? DSLH;
    // Thuat toan lien quan den Loai Hang
    
    public QLDL()
    {
        DSLH = new List<LoaiHang>();
    }
    public static bool LoaiHangUpdateDS(List<LoaiHang>? DSLoaiHang)
    {
        var data = DataLoad();
        data.DSLH = DSLoaiHang;
        return DataWorkFlow.DataSave(data);
    }
    public void loadDSLH()
        {
            var dl = DataWorkFlow.DataLoad();
            this.DSLH = dl.DSLH;
        }
    public bool LHtao(LoaiHang LoaiHangmoi)
    {
        var data = DataLoad();
        
        var Curent = new List<LoaiHang>();
        Curent = data.DSLH;
        Curent.Add(LoaiHangmoi);
        data.DSLH = new List<LoaiHang>();
        data.DSLH = Curent;

        return DataWorkFlow.DataSave(data);
    }

    public bool LHxoa(string MaLH)
    {
        var DL = DataWorkFlow.DataLoad();
        var ds = LHxuatDS(false);
        for (int i = 0; i < DL.DSLH.Count; i++)
        {
            if (DL.DSLH[i].ID()==MaLH)
            {
                ds[i].RemoveItem();
            }
        }
        return LoaiHangUpdateDS(ds);
    }

    public static QLDL? DataLoad()
    {
        return DataWorkFlow.DataLoad();
    }

    public static List<LoaiHang>? LHxuatDS(bool isIncludeDelete)
    {
        var result = new List<LoaiHang>();
        var data = DataLoad();
        if (data == null)
        {
            return result;
        }
       
        List<LoaiHang>? Curent = data.DSLH;
        foreach (LoaiHang loaiHang  in Curent)
        {
            if (isIncludeDelete==false && loaiHang.IsDelete)
            {
                continue;
            }
            result.Add(loaiHang);
        }
        return result;
    }

    public static string[] LHxuatIdList() // ho tro tao ma
    {
        var listID = new List<string>();
        var Data = DataLoad();
        List<LoaiHang>? current = LHxuatDS(false);
        foreach (LoaiHang hang in current)
        {
            listID.Add(hang.ID());
        }

        return listID.ToArray();
    }

    public static string LHten(List<LoaiHang> dsLoaiHangs,string MaLoai)
    {
        foreach (LoaiHang hang in dsLoaiHangs)
        {
            if (hang.ID()==MaLoai)
            {
                return hang.Name;
            }
        }

        return null;
    }



    // thuat toan lien quan San Pham
    public bool SPTao(Sp SanPhamMoi)
    {
        throw new NotImplementedException();
    }

    private string Note(bool ketqua)
    {
        if (ketqua)
        {
            return "Thành Công";
        }
        else
        {
            return "Thất Bại";
        }
    }

    




}