

//$(document).ready(function () {
//    $.ajax({
//        url: "https://localhost:7146/api/Araba/ArabaListesi",
//        type: "GET",
//        datatype: "json",
//        contentType: "application/json;charset=utf-8",
//        success: function (data) {
//            console.log(data); // Gelen veriyi konsolda yazdırarak kontrol edelim
//            $.each(data, function (i, araba) {
//                console.log(araba); // Her araba nesnesini konsolda yazdırarak kontrol edelim
//                let arabaSatiri = "<tr>" +
//                    "<td>" + araba.id + "</td>" +
//                    "<td>" + araba.marka + "</td>" +
//                    "<td>" + araba.renk + "</td>" +
//                    "<td> <button class='btn btn-secondary' id='detay" + i + "' onclick='Detay(" + araba.id + ")'> Detay </button> " +
//                    " <button class='btn btn-danger' id='Sil" + "' onclick='Sil(" + araba.id + ")'> Sil </button> " +
//                    " <button class='btn btn-primary' data-bs-toggle='modal' data-bs-target='#guncellemePenrecesi' id='duzenle" + i + "' onclick='VeriAktar(" + araba.id + ")'> Düzenle </button> " +
//                    "</td> </tr>";
//                $("#tblArabalar tbody").append(arabaSatiri);
//            });
//        },
//        error: function () {
//            alert("Hata oluştu!");
//        }
//    });
//});





////function Sil(id) {

////    $.ajax({
////        url: "https://localhost:7146/api/Araba/ArabaSil?id=" + id,
////        type: "POST",
////        success: function () {
////            alert("İlgili araba silindi.");
////            location.reload("/Home/Privacy");
////        },
////        error: function () {
////            alert("Hata oluştu");
////        }

////    });
////}


//function AracEkle() {
//    let araba = {
//        marka: $("#txtMarka").val(),
//        renk: $("#txtRenk").val()
//    };
//    console.log(data);

//    $.ajax(
//        {
//            url: "https://localhost:7146/api/Araba/ArabaEkle",
//            type: "post",
//            data: JSON.stringify(araba),
//            headers: {
//                "Content-Type": "application/json"
//            },
//            success: function (data) {
//                if (araba.marka == "" || araba.renk == "") {
//                    alert("Lütfen alanları doldurunuz");
//                    location.reload("Home/Privacy");
//                }
//                else {
//                    alert("Başarıyla eklenmiştir");
//                    location.reload("Home/Privacy");
//                }

//            },

//            error: function () {
//                console.log(data);

//                alert("Hata oluştu!");
//            }


//        });
//}




////function VeriAktar(id) {
////    $.ajax({
////        url: "https://localhost:7146/api/Araba/ArabaGuncelle?id=" + id,
////        type: "POST",
////        success: function (data) {
////            $("#txtId").val(data.id),
////                $("#txtGuncellenenMarka").val(data.marka),
////                $("#txtGuncellenenFiyat").val(data.fiyat),
////                $("#chcIkinciElMi").prop("checked", data.durum)



////        },
////        error: function () {
////            alert("Hata oluştu");
////        }

////    });
////}

//------------------------------------------------------------------------------




    $(document).ready(function () {
        $.ajax({
            url: "https://localhost:7146/api/Araba/ArabaListesi",
            type: "get",
            datatype: "JSON",
            contentType: "application/json;charset=utf-8",
            success: function (data) {
                console.log(data);
                $.each(data, function (i, araba) {
                    let arabaSatiri = "<tr>" +
                        "<td>" + araba.id + "</td>" +
                        "<td>" + araba.marka + "</td>" +
                        "<td>" + araba.renk + "</td>" +
                      
                        "<td> <button class='btn btn-secondary' id='detay" + i + "' onclick='Detay(" + araba.id + ")'> Detay </button> " +
                        " <button class='btn btn-danger' id='sil" + i + "' onclick='Sil(" + araba.id + ")'> Sil </button> " +
                        " <button class='btn btn-primary' id='duzenle" + i + "' onclick='VeriAktar(" + araba.id + ")' data-bs-toggle='modal' data-bs-target='#guncellemePenrecesi'> Düzenle </button> " +
                        "</td> </tr>";
                    $("#tblArabalar tbody").append(arabaSatiri);
                });
            },
            error: function () {
                alert("Hata oluştu!");
            }
        });
    });

    function Sil(id) {
        $.ajax(

            {

                url: "https://localhost:7146/api/Araba/ArabaSil?id=" + id,
                type: "post",

                success: function () {

                    alert("Başarıyla silinmiştir");
                    location.reload("Home/Index");


                },

                error: function () {

                    alert("Hata oluştu!");
                }

            });
    }

    function Ekle() {
  

            //bu butona tıklandığı zaman texboxlardan alınan bilgileri yeni bir esya objesine atamalı
            //sonra bu objeyi de metoda göndermeliyiz.

            let araba = {
                marka: $("#txtMarka").val(),
                renk: $("#txtRenk").val()
            };

            $.ajax(

                {
                    
                    url: "https://localhost:7146/api/Araba/ArabaEkle",
                type: "post",
                data: JSON.stringify(araba),
                    headers: {
                        "Content-Type": "application/json"
                    },


                    success: function (data) {

                    if (araba.marka == "" || araba.renk == "") {
                            alert("Lütfen alanları doldurunuz");
                            location.reload("Home/Index");
                        }
                        else {
                            alert("Başarıyla eklenmiştir");
                        location.reload("Home/Index");
                        }

                    },

                    error: function () {

                        alert("Hata oluştu!");
                    }



                });


       

        
    }
    function VeriAktar(id) {
        // //hangi arabanın yanındaki düzenleye tıklandıysa, o arabanın bilgilerini modal'a taşıyan fonksiyon

        // //önce bu id'ye ait alan arabayı bulalım ve onun bilgilerini modal 'a yazdıralım.
        // //bulabilmek için id'ye göre getirmemiz lazım.
        $.ajax({
            url: "https://localhost:7146/api/Araba/ArabaGuncelle?id=" + id,
            type: "Get",
            datatype: "JSON",
            contentType: "application/json;charset=utf-8",

            success: function (data) {
                //Başarılı olduğu zaman id'ye göre arabanın bütün bilgilerini modal ' a yani açılan penreceye gönder.
                $("#txtId").val(data.id);
                $("#txtGuncelMarka").val(data.marka);
                $("#txtGuncelFiyat").val(data.fiyat);
                $("#chcGuncelDurum").prop("checked", data.durum);  //checked özelliğine data'nın durumunu ata
            },
            error: function () {
                alert("Hata oluştu");
            }

        });

    }
    function Guncelle(id) {
        //gelen id'ye göre arabayı tekrar getirelim ve diğer textboxlardan gelen değerlerle oluşan araba objesinin özelliklerini, id'ye göre getirilen arabanın özelliklerine atanmasını sağlayalım.

        //Bunun için Controllerdaki güncelleme metoduna, id'yi ve özellikleri alınacak objeyi göndermemiz gereklidir. Daha sonra yukarıda belirtilen işlemleri, controllerdaki metoda yazacağız.

        let guncelOzellikleriTemsilEden = {
            marka: $("#txtGuncelMarka").val(),
            fiyat: $("#txtGuncelFiyat").val(),
            durum: $("#chcGuncelDurum").is(":checked")
        };
        //Sonra ajax vasıtasıyla controllerdaki güncelleme metodunu çağıracağız.

        $.ajax({
            url: "https://localhost:7000/Home/Guncelle/" + id,
            type: "Post",
            data: guncelOzellikleriTemsilEden,

            success: function () {
                alert("Başarılı bir şekilde güncellenmiştir");
                location.reload("Home/Index");
            },
            error: function () {
                alert("Hata Oluştu!");
            }


        });
    }
    function Detay(id) {
        //yine id'ye göre getir ve kayıt , güncellenme tarihini (varsa) alert ile yazdır.

        $.ajax({
            url: "https://localhost:7000/Home/IdyeGoreGetir/" + id,
            type: "Get",
            datatype: "JSON",
            contentType: "application/json;charset=utf-8",

            success: function (data) {
                if (data.guncellenmeTarihi == null)
                    alert("Kayıt Tarihi: " + data.kayitTarihi + "\nGüncellenme Tarihi Yoktur!");
                else
                    alert("Kayıt Tarihi: " + data.kayitTarihi + "\nGüncellenme Tarihi: " + data.guncellenmeTarihi);
            },
            error: function () {
                alert("Hata oluştu");
            }

        });
    }
