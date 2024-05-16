using BemBankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BemBankApp.Controllers
{
    public class PayController : ApiController
    {
        BemBankEntities db = new BemBankEntities();
        //https://localhost:44386/API/Pay?kartno=4587458965874125&sonkullanmaAy=12&sonkullanmayil=25&CVV=105&fiyat=45.4
        public string Get(string kartno, string sonkullanmaAy, string sonkullanmayil, string CVV, decimal fiyat)
        {
            Hesaplar h = db.Hesaplar.FirstOrDefault(x => x.KartNo == kartno);

            if (h != null)
            {
                if (sonkullanmayil == h.SonKullanmaYil && sonkullanmaAy == h.SonKullanmaAy)
                {
                    DateTime kart = Convert.ToDateTime(DateTime.Now.Day + "-" + sonkullanmaAy + "-" + sonkullanmayil);

                    if (kart >= DateTime.Now)
                    {
                        if (CVV == h.CVV)
                        {
                            if (Convert.ToBoolean(h.Aktif))
                            {
                                if (h.Bakiye > fiyat)
                                {
                                    try
                                    {
                                        int id = db.Hesaplar.FirstOrDefault(x => x.KartNo == kartno).ID;
                                        Hesaplar hh = db.Hesaplar.Find(id);
                                        hh.Bakiye -= fiyat;
                                        db.SaveChanges();
                                        return "201";
                                    }
                                    catch
                                    {
                                        return "301";
                                    }
                                }
                                else
                                {
                                    return "401";
                                }
                            }
                            else
                            {
                                return "501";
                            }
                        }
                        else
                        {
                            return "601";
                        }
                    }
                    else
                    {
                        return "701";
                    }
                }
                else
                {
                    return "801";
                }
            }
            else
            {
                return "901";
            }
            return "";
        }
    }
}
