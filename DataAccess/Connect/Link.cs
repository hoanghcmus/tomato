using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using DataAccess.Help;

namespace DataAccess.Connect
{
    public static class Link
    {
        #region Uri
        private static string BuildAbsolute(string relativeUrl)
        {
            Uri uri = HttpContext.Current.Request.Url;
            string app = HttpContext.Current.Request.ApplicationPath;
            if (!app.EndsWith("/"))
                app += "/";
            relativeUrl = relativeUrl.TrimStart('/');
            return HttpUtility.UrlPathEncode(String.Format("http://{0}:{1}{2}{3}", uri.Host, uri.Port, app, relativeUrl));
        }
        #endregion

        #region link Website
        public static string Toimages(string fileName)
        {
            return String.Format(fileName);
        }
        public static string ToFiles(string fileName)
        {
            return String.Format(fileName);
        }
        #endregion

        public static string ListTour_Vn(string theLoai)
        {
            return ListTour_Vn(theLoai, "1");
        }
        public static string ListTour_Vn(string theLoai, string trang)
        {
            if (trang == "1")
                return BuildAbsolute(String.Format("/vn/travel-tour-{0}.html", theLoai));
            return BuildAbsolute(String.Format("/vn/travel-tour-{0}.html?Page={1}", theLoai, trang));
        }

        public static string ListTour_En(string theLoai)
        {
            return ListTour_En(theLoai, "1");
        }
        public static string ListTour_En(string theLoai, string trang)
        {
            if (trang == "1")
                return BuildAbsolute(String.Format("/en/travel-tour-{0}.html", theLoai));
            return BuildAbsolute(String.Format("/en/travel-tour-{0}.html?Page={1}", theLoai, trang));
        }


        public static string ListTour_Ru(string theLoai)
        {
            return ListTour_Ru(theLoai, "1");
        }
        public static string ListTour_Ru(string theLoai, string trang)
        {
            if (trang == "1")
                return BuildAbsolute(String.Format("/ru/travel-tour-{0}.html", theLoai));
            return BuildAbsolute(String.Format("/ru/travel-tour-{0}.html?Page={1}", theLoai, trang));
        }

        // for article - start

        public static string ListArticle_Vn(string title, string theLoai, string activeMenuItemID)
        {
            return ListArticle_Vn(title, theLoai, activeMenuItemID, "1");
        }
        public static string ListArticle_Vn(string title, string theLoai, string activeMenuItemID, string trang)
        {
            if (trang == "1")
                return BuildAbsolute(String.Format("/vn/news/{0}-{1}-{2}.html", title, theLoai, activeMenuItemID));
            return BuildAbsolute(String.Format("/vn/news/{0}-{1}-{2}.html?Page={4}", title, theLoai, activeMenuItemID, trang));
        }

        public static string ListArticle_En(string title, string theLoai, string activeMenuItemID)
        {
            return ListArticle_En(title, theLoai, activeMenuItemID, "1");
        }
        public static string ListArticle_En(string title, string theLoai, string activeMenuItemID, string trang)
        {
            if (trang == "1")
                return BuildAbsolute(String.Format("/en/news/{0}-{1}-{2}.html", title, theLoai, activeMenuItemID));
            return BuildAbsolute(String.Format("/en/news/{0}-{1}-{2}.html?Page={4}", title, theLoai, activeMenuItemID, trang));
        }


        public static string ListArticle_Ru(string title, string theLoai, string activeMenuItemID)
        {
            return ListArticle_Ru(title, theLoai, activeMenuItemID, "1");
        }
        public static string ListArticle_Ru(string title, string theLoai, string activeMenuItemID, string trang)
        {
            if (trang == "1")
                return BuildAbsolute(String.Format("/ru/news/{0}-{1}-{2}.html", title, theLoai, activeMenuItemID));
            return BuildAbsolute(String.Format("/ru/news/{0}-{1}-{2}.html?Page={4}", title, theLoai, activeMenuItemID, trang));
        }
        // for article - end

        public static string DetailTour(string id)
        {
            return BuildAbsolute(String.Format("DetailTour.aspx?ID={0}", id));
        }

        #region VietNam
        public static string Photos(string trang)
        {
            if (trang == "1")
                return BuildAbsolute(String.Format("../hinh-anh.html"));
            return BuildAbsolute(String.Format("../hinh-anh.html?Page={0}", trang));
        }
        public static string Photos()
        {
            return Photos("1");
        }
        public static string Videos(string trang)
        {
            if (trang == "1")
                return BuildAbsolute(String.Format("../vn-video-clips.html"));
            return BuildAbsolute(String.Format("../vn-video-clips.html?Page={0}", trang));
        }
        public static string Videos()
        {
            return Videos("1");
        }
        public static string DetailArticle(string title, string id, string menuActiveID)
        {
            string valus = Helper.RejectMarks(title);
            return BuildAbsolute(String.Format("../en/article/{0}-{1}-{2}.html", valus, id, menuActiveID));
        }
        public static string DetailServices(string title, string id)
        {
            string valus = Helper.RejectMarks(title);
            return BuildAbsolute(String.Format("../dich-vu/{0}-{1}.html", valus, id));
        }
        public static string DetailAbouts(string title, string id)
        {
            string valus = Helper.RejectMarks(title);
            return BuildAbsolute(String.Format("../gioi-thieu/{0}-{1}.html", valus, id));
        }
        public static string DetailProduct(string title, string id)
        {
            string valus = Helper.RejectMarks(title);
            return BuildAbsolute(String.Format("../en/view-room/{0}-{1}.html", valus, id));
        }
        public static string DetailPhoto(string title, string id)
        {
            string valus = Helper.RejectMarks(title);
            return BuildAbsolute(String.Format("../en/gallery/{0}-{1}.html", valus, id));
        }
        public static string Categorys(string title, string theLoai, string trang)
        {
            string valus = Helper.RejectMarks(title);
            if (trang == "1")
                return BuildAbsolute(String.Format("../the-loai/{0}-{1}.html", valus, theLoai));
            return BuildAbsolute(String.Format("../the-loai/{0}-{1}.html?Page={2}", valus, theLoai, trang));
        }
        public static string Categorys(string title, string theLoai)
        {
            return Categorys(title, theLoai, "1");
        }
        public static string CategorysList(string title, string theLoai, string trang)
        {
            string valus = Helper.RejectMarks(title);
            if (trang == "1")
                return BuildAbsolute(String.Format("../danh-sach-the-loai/{0}-{1}.html", valus, theLoai));
            return BuildAbsolute(String.Format("../danh-sach-the-loai/{0}-{1}.html?Page={2}", valus, theLoai, trang));
        }
        public static string CategorysList(string title, string theLoai)
        {
            return CategorysList(title, theLoai, "1");
        }
        public static string Products(string title, string theLoai, string trang)
        {
            string valus = Helper.RejectMarks(title);
            if (trang == "1")
                return BuildAbsolute(String.Format("../phong/{0}-{1}.html", valus, theLoai));
            return BuildAbsolute(String.Format("../phong/{0}-{1}.html?Page={2}", valus, theLoai, trang));
        }
        public static string Products(string title, string theLoai)
        {
            return Products(title, theLoai, "1");
        }
        public static string AddToRoom(string productId)
        {
            return BuildAbsolute(String.Format("En/ProAddToRoom.aspx?ID={0}", productId));
        }

        public static string AddToTour(string productId)
        {
            return BuildAbsolute(String.Format("En/AddToTour.aspx?ID={0}", productId));
        }
        #endregion

        #region English
        public static string EnPhotos(string trang)
        {
            if (trang == "1")
                return BuildAbsolute(String.Format("../Photos.html"));
            return BuildAbsolute(String.Format("../Photos.html?Page={0}", trang));
        }
        public static string EnPhotos()
        {
            return EnPhotos("1");
        }
        public static string EnVideos(string trang)
        {
            if (trang == "1")
                return BuildAbsolute(String.Format("../en-video-clips.html"));
            return BuildAbsolute(String.Format("../en-video-clips.html?Page={0}", trang));
        }
        public static string EnVideos()
        {
            return EnVideos("1");
        }
        public static string EnDetailArticle(string title, string id)
        {
            string valus = Helper.RejectMarks(title);
            return BuildAbsolute(String.Format("../Articles/{0}-{1}.html", valus, id));
        }
        public static string EnDetailServices(string title, string id)
        {
            string valus = Helper.RejectMarks(title);
            return BuildAbsolute(String.Format("../Services/{0}-{1}.html", valus, id));
        }
        public static string EnDetailAbouts(string title, string id)
        {
            string valus = Helper.RejectMarks(title);
            return BuildAbsolute(String.Format("../Abouts/{0}-{1}.html", valus, id));
        }
        public static string EnDetailProduct(string title, string id)
        {
            string valus = Helper.RejectMarks(title);
            return BuildAbsolute(String.Format("../View-Room/{0}-{1}.html", valus, id));
        }
        public static string EnDetailPhoto(string title, string id)
        {
            string valus = Helper.RejectMarks(title);
            return BuildAbsolute(String.Format("../Photos/{0}-{1}.html", valus, id));
        }
        public static string EnCategorys(string title, string theLoai, string trang)
        {
            string valus = Helper.RejectMarks(title);
            if (trang == "1")
                return BuildAbsolute(String.Format("../Categorys/{0}-{1}.html", valus, theLoai));
            return BuildAbsolute(String.Format("../Categorys/{0}-{1}.html?Page={2}", valus, theLoai, trang));
        }
        public static string EnCategorys(string title, string theLoai)
        {
            return EnCategorys(title, theLoai, "1");
        }
        public static string EnCategorysList(string title, string theLoai, string trang)
        {
            string valus = Helper.RejectMarks(title);
            if (trang == "1")
                return BuildAbsolute(String.Format("../Categorys-list/{0}-{1}.html", valus, theLoai));
            return BuildAbsolute(String.Format("../Categorys-list/{0}-{1}.html?Page={2}", valus, theLoai, trang));
        }
        public static string EnCategorysList(string title, string theLoai)
        {
            return EnCategorysList(title, theLoai, "1");
        }
        public static string EnProducts(string title, string theLoai, string trang)
        {
            string valus = Helper.RejectMarks(title);
            if (trang == "1")
                return BuildAbsolute(String.Format("../Room/{0}-{1}.html", valus, theLoai));
            return BuildAbsolute(String.Format("../Room/{0}-{1}.html?Page={2}", valus, theLoai, trang));
        }
        public static string EnProducts(string title, string theLoai)
        {
            return EnProducts(title, theLoai, "1");
        }
        public static string EnAddToRoom(string productId)
        {
            return BuildAbsolute(String.Format("En/ProAddToRoom.aspx?ID={0}", productId));
        }
        #endregion

        #region Russia
        public static string RuPhotos(string trang)
        {
            if (trang == "1")
                return BuildAbsolute(String.Format("../фото.html"));
            return BuildAbsolute(String.Format("../фото.html?Page={0}", trang));
        }
        public static string RuPhotos()
        {
            return RuPhotos("1");
        }
        public static string RuVideos(string trang)
        {
            if (trang == "1")
                return BuildAbsolute(String.Format("../ru-video-clips.html"));
            return BuildAbsolute(String.Format("../ru-video-clips.html?Page={0}", trang));
        }
        public static string RuVideos()
        {
            return RuVideos("1");
        }
        public static string RuDetailArticle(string title, string id)
        {
            string valus = Helper.RejectMarks(title);
            return BuildAbsolute(String.Format("../статьи/{0}-{1}.html", valus, id));
        }
        public static string RuDetailServices(string title, string id)
        {
            string valus = Helper.RejectMarks(title);
            return BuildAbsolute(String.Format("../услуги/{0}-{1}.html", valus, id));
        }
        public static string RuDetailAbouts(string title, string id)
        {
            string valus = Helper.RejectMarks(title);
            return BuildAbsolute(String.Format("../введение/{0}-{1}.html", valus, id));
        }
        public static string RuDetailProduct(string title, string id)
        {
            string valus = Helper.RejectMarks(title);
            return BuildAbsolute(String.Format("../View-номер/{0}-{1}.html", valus, id));
        }
        public static string RuDetailPhoto(string title, string id)
        {
            string valus = Helper.RejectMarks(title);
            return BuildAbsolute(String.Format("../фото/{0}-{1}.html", valus, id));
        }
        public static string RuCategorys(string title, string theLoai, string trang)
        {
            string valus = Helper.RejectMarks(title);
            if (trang == "1")
                return BuildAbsolute(String.Format("../категория/{0}-{1}.html", valus, theLoai));
            return BuildAbsolute(String.Format("../категория/{0}-{1}.html?Page={2}", valus, theLoai, trang));
        }
        public static string RuCategorys(string title, string theLoai)
        {
            return RuCategorys(title, theLoai, "1");
        }
        public static string RuCategorysList(string title, string theLoai, string trang)
        {
            string valus = Helper.RejectMarks(title);
            if (trang == "1")
                return BuildAbsolute(String.Format("../категория-list/{0}-{1}.html", valus, theLoai));
            return BuildAbsolute(String.Format("../категория-list/{0}-{1}.html?Page={2}", valus, theLoai, trang));
        }
        public static string RuCategorysList(string title, string theLoai)
        {
            return RuCategorysList(title, theLoai, "1");
        }
        public static string RuProducts(string title, string theLoai, string trang)
        {
            string valus = Helper.RejectMarks(title);
            if (trang == "1")
                return BuildAbsolute(String.Format("../номер/{0}-{1}.html", valus, theLoai));
            return BuildAbsolute(String.Format("../номер/{0}-{1}.html?Page={2}", valus, theLoai, trang));
        }
        public static string RuProducts(string title, string theLoai)
        {
            return RuProducts(title, theLoai, "1");
        }
        public static string RuAddToRoom(string productId)
        {
            return BuildAbsolute(String.Format("Ru/ProAddToRoom.aspx?ID={0}", productId));
        }
        #endregion

        #region link Manager Article
        public static string MgerArticle(string _TrangThai, string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerArticle.aspx?Status={0}", _TrangThai));
            else
                return BuildAbsolute(String.Format("Admin/MgerArticle.aspx?Status={0}&Page={1}", _TrangThai, _Trang));
        }
        public static string MgerArticle(string _TrangThai)
        {
            return MgerArticle(_TrangThai, "1");
        }
        public static string EditArticle(string id)
        {
            return BuildAbsolute(String.Format("Admin/EditArticle.aspx?ID={0}", id));
        }
        public static string EditArticleToMenu(string _TheLoai, string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerArticle.aspx?ID={0}", _TheLoai));
            else
                return BuildAbsolute(String.Format("Admin/MgerArticle.aspx?ID={0}&Page={1}", _TheLoai, _Trang));
        }
        public static string EditArticleToMenu(string _TheLoai)
        {
            return EditArticleToMenu(_TheLoai, "1");
        }
        public static string EditArticleToSreach(string chuoiTimKiem, string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerArticle.aspx?Search={0}", chuoiTimKiem));
            else
                return BuildAbsolute(String.Format("Admin/MgerArticle.aspx?Search={0}&Page={1}", chuoiTimKiem, _Trang));
        }
        public static string EditArticleToSreach(string chuoiTimKiem)
        {
            return EditArticleToSreach(chuoiTimKiem, "1");
        }
        public static string MgerContact(string _TinhTrang, string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerContact.aspx?Status={0}", _TinhTrang));
            else
                return BuildAbsolute(String.Format("Admin/MgerContact.aspx?Status={0}&Page={1}", _TinhTrang, _Trang));
        }
        public static string MgerContact(string _TinhTrang)
        {
            return MgerContact(_TinhTrang, "1");
        }

        public static string MgerHoiDap(string _TinhTrang, string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerLetter.aspx?Status={0}", _TinhTrang));
            else
                return BuildAbsolute(String.Format("Admin/MgerLetter.aspx?Status={0}&Page={1}", _TinhTrang, _Trang));
        }
        public static string MgerHoiDap(string _TinhTrang)
        {
            return MgerHoiDap(_TinhTrang, "1");
        }



        public static string HoiDap_Vn(string _TinhTrang, string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("/vn/contact-9.html", _TinhTrang));
            else
                return BuildAbsolute(String.Format("/vn/contact-9.html?Page={1}", _TinhTrang, _Trang));
        }
        public static string HoiDap_Vn(string _TinhTrang)
        {
            return HoiDap_Vn(_TinhTrang, "1");
        }

        public static string HoiDap_En(string _TinhTrang, string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("/en/contact-9.html", _TinhTrang));
            else
                return BuildAbsolute(String.Format("/en/contact-9.html?Page={1}", _TinhTrang, _Trang));
        }
        public static string HoiDap_En(string _TinhTrang)
        {
            return HoiDap_En(_TinhTrang, "1");
        }

        public static string HoiDap_Ru(string _TinhTrang, string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("/ru/contact-9.html", _TinhTrang));
            else
                return BuildAbsolute(String.Format("/ru/contact-9.html?Page={1}", _TinhTrang, _Trang));
        }
        public static string HoiDap_Ru(string _TinhTrang)
        {
            return HoiDap_Ru(_TinhTrang, "1");
        }
        #endregion

        #region link Manager Images And Clips
        /// Images
        public static string MgerPhoto(string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerPhoto.aspx"));
            else
                return BuildAbsolute(String.Format("Admin/MgerPhoto.aspx?Page={0}", _Trang));
        }
        public static string MgerPhoto()
        {
            return MgerPhoto("1");
        }
        public static string EditPhoto(string id)
        {
            return BuildAbsolute(String.Format("Admin/EditPhoto.aspx?ID={0}", id));
        }
        public static string MgerPhotoToSreach(string chuoiTimKiem, string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerPhoto.aspx?Search={0}", chuoiTimKiem));
            else
                return BuildAbsolute(String.Format("Admin/MgerPhoto.aspx?Search={0}&Page={1}", chuoiTimKiem, _Trang));
        }
        public static string MgerPhotoToSreach(string chuoiTimKiem)
        {
            return MgerPhotoToSreach(chuoiTimKiem, "1");
        }
        /// Clips-Videos
        public static string MgerVideo(string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerVideo.aspx?"));
            else
                return BuildAbsolute(String.Format("Admin/MgerVideo.aspx?Page={0}", _Trang));
        }
        public static string MgerVideo()
        {
            return MgerVideo("1");
        }
        public static string EditVideo(string id)
        {
            return BuildAbsolute(String.Format("Admin/EditVideo.aspx?ID={0}", id));
        }
        public static string MgerVideoToSreach(string chuoiTimKiem, string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerVideo.aspx?Search={0}", chuoiTimKiem));
            else
                return BuildAbsolute(String.Format("Admin/MgerVideo.aspx?Search={0}&Page={1}", chuoiTimKiem, _Trang));
        }
        public static string MgerVideoToSreach(string chuoiTimKiem)
        {
            return MgerVideoToSreach(chuoiTimKiem, "1");
        }
        #endregion

        #region link Manager Product
        public static string MgerProduct(string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerProduct.aspx?"));
            else
                return BuildAbsolute(String.Format("Admin/MgerProduct.aspx?Page={0}", _Trang));
        }
        public static string MgerProduct()
        {
            return MgerProduct("1");
        }
        public static string EditProduct(string id)
        {
            return BuildAbsolute(String.Format("Admin/EditProduct.aspx?ID={0}", id));
        }
        public static string MgerProductToMenu(string _TheLoai, string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerProduct.aspx?MenID={0}", _TheLoai));
            else
                return BuildAbsolute(String.Format("Admin/MgerProduct.aspx?MenID={0}&Page={1}", _TheLoai, _Trang));
        }
        public static string MgerProductToMenu(string _TheLoai)
        {
            return MgerProductToMenu(_TheLoai, "1");
        }


        public static string MgerProductToSreach(string chuoiTimKiem, string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerProduct.aspx?Search={0}", chuoiTimKiem));
            else
                return BuildAbsolute(String.Format("Admin/MgerProduct.aspx?Search={0}&Page={1}", chuoiTimKiem, _Trang));
        }
        public static string MgerProductToSreach(string chuoiTimKiem)
        {
            return MgerProductToSreach(chuoiTimKiem, "1");
        }
        #endregion

        #region link Manager Dat Phong
        public static string MgerDatPhongState(string _TinhTrang, string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerDatPhong.aspx?TinhTrang={0}", _TinhTrang));
            else
                return BuildAbsolute(String.Format("Admin/MgerDatPhong.aspx?TinhTrang={0}&Trang={1}", _TinhTrang, _Trang));
        }
        public static string MgerDatPhongState(string _TinhTrang)
        {
            return MgerDatPhongState(_TinhTrang, "1");
        }
        public static string MgerDatPhong(string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerDatPhong.aspx"));
            else
                return BuildAbsolute(String.Format("Admin/MgerDatPhong.aspx?Trang={0}", _Trang));
        }
        public static string MgerDatPhong()
        {
            return MgerDatPhong("1");
        }
        #endregion

        #region Link Manger DatTiec
        public static string MgerDatTiecState(string _TinhTrang, string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerDatTiec.aspx?TinhTrang={0}", _TinhTrang));
            else
                return BuildAbsolute(String.Format("Admin/MgerDatTiec.aspx?TinhTrang={0}&Trang={1}", _TinhTrang, _Trang));
        }
        public static string MgerDatTiecState(string _TinhTrang)
        {
            return MgerDatTiecState(_TinhTrang, "1");
        }

        public static string MgerDatTiec(string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerDatTiec.aspx"));
            else
                return BuildAbsolute(String.Format("Admin/MgerDatTiec.aspx?Trang={0}", _Trang));
        }
        public static string MgerDatTiec()
        {
            return MgerDatTiec("1");
        }
        #endregion

        #region Link Manager User
        public static string MgerLogin(string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerLogin.aspx"));
            else
                return BuildAbsolute(String.Format("Admin/MgerLogin.aspx?Page={0}", _Trang));
        }
        public static string MgerLogin()
        {
            return MgerLogin("1");
        }

        public static string MgerLoginUser(string _maNguoiDung, string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerLogin.aspx?User={0}", _maNguoiDung));
            else
                return BuildAbsolute(String.Format("Admin/MgerLogin.aspx?User={0}&Page={1}", _maNguoiDung, _Trang));
        }
        public static string MgerLoginUser(string _maNguoiDung)
        {
            return MgerLoginUser(_maNguoiDung, "1");
        }
        #endregion

        #region link Manager Tour
        public static string MgerTour(string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerTour.aspx?"));
            else
                return BuildAbsolute(String.Format("Admin/MgerTour.aspx?Trang={0}", _Trang));
        }
        public static string MgerTour()
        {
            return MgerTour("1");
        }
        public static string EditTour(string id)
        {
            return BuildAbsolute(String.Format("Admin/EditTour.aspx?ID={0}", id));
        }
        public static string MgerTourToMenu(string _TheLoai, string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerTour.aspx?ID={0}", _TheLoai));
            else
                return BuildAbsolute(String.Format("Admin/MgerTour.aspx?ID={0}&Trang={1}", _TheLoai, _Trang));
        }
        public static string MgerTourToMenu(string _TheLoai)
        {
            return MgerTourToMenu(_TheLoai, "1");
        }
        public static string MgerTourToSreach(string chuoiTimKiem, string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerTour.aspx?ChuoiTimKiem={0}", chuoiTimKiem));
            else
                return BuildAbsolute(String.Format("Admin/MgerTour.aspx?ChuoiTimKiem={0}&Trang={1}", chuoiTimKiem, _Trang));
        }
        public static string MgerTourToSreach(string chuoiTimKiem)
        {
            return MgerTourToSreach(chuoiTimKiem, "1");
        }
        public static string MgerDatTourState(string _TinhTrang, string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerDatTour.aspx?TinhTrang={0}", _TinhTrang));
            else
                return BuildAbsolute(String.Format("Admin/MgerDatTour.aspx?TinhTrang={0}&Trang={1}", _TinhTrang, _Trang));
        }
        public static string MgerDatTourState(string _TinhTrang)
        {
            return MgerDatTourState(_TinhTrang, "1");
        }
        public static string MgerDatTour(string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerDatTour.aspx"));
            else
                return BuildAbsolute(String.Format("Admin/MgerDatTour.aspx?Trang={0}", _Trang));
        }
        public static string MgerDatTour()
        {
            return MgerDatTour("1");
        }
        #endregion
    }
}
