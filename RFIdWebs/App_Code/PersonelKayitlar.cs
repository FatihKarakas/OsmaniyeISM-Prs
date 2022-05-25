using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/// <summary>
/// PersonelKayitlar için özet açıklama
/// </summary>
public class PersonelKayitlar
{
    public PersonelKayitlar()
    {
        //
        //TODO: Buraya oluşturucu mantığı ekleyin
        //
    }
    public ICollection<PersonelBilgi> GetAllUserInfo(ZkemClient objZkeeper, int machineNumber=1)
    {
        string sdwEnrollNumber = string.Empty, sName = string.Empty, sPassword = string.Empty, sTmpData = string.Empty;
        int iPrivilege = 0, iTmpLength = 0, iFlag = 0, idwFingerIndex;
        bool bEnabled = false;
        ICollection<PersonelBilgi> lstFPTemplates = new List<PersonelBilgi>();
        objZkeeper.ReadAllUserID(machineNumber);
        objZkeeper.ReadAllTemplate(machineNumber);
        while (objZkeeper.SSR_GetAllUserInfo(machineNumber, out sdwEnrollNumber, out sName, out sPassword, out iPrivilege, out bEnabled))
        {
            //for (idwFingerIndex = 0; idwFingerIndex < 10; idwFingerIndex++)
            //{
            idwFingerIndex = 0;
            var son = objZkeeper.GetUserTmpExStr(machineNumber, sdwEnrollNumber, idwFingerIndex, out iFlag, out sTmpData, out iTmpLength);
            //if (objZkeeper.GetUserTmpExStr(machineNumber, sdwEnrollNumber, idwFingerIndex, out iFlag, out sTmpData, out iTmpLength))
            //{
            PersonelBilgi fpInfo = new PersonelBilgi();
            fpInfo.MakineNo = machineNumber;
            fpInfo.KullaniciNo = sdwEnrollNumber;
            fpInfo.PersonelAdi = sName;
            fpInfo.FingerIndex = idwFingerIndex;
            fpInfo.TmpData = sTmpData;
            fpInfo.Privelage = iPrivilege;
            fpInfo.Parola = sPassword;
            fpInfo.Aktifmi = bEnabled;
            fpInfo.iFlag = iFlag.ToString();
            lstFPTemplates.Add(fpInfo);
            //}
            //}
        }
        return lstFPTemplates;
    }
}