$(function () {
    $('#EABD_Id').change(function () {
        var id = $('#EABD_Id').val();
        var lang = $('#culture_RequestCulture_UICulture_Name').val();
        console.log(lang);
        if (id == '') {
            $.ajax({
                url: '/Program/TumProgramlar',
                type: 'GET',
                dataType: 'json',
                success: function (data) {
                    $('#Prog_Id').empty();
                    var options = $("#Prog_Id");
                    console.log("data=", data)
                    $.each(data, function (index, result) {
                        options.append($("<option/>").val(result.Value).text(result.Text));
                    }
                    )
                }
            });
        }
        else {
            $.ajax({
                url: '/Program/ProgramGoster',
                data: { p: id, lang: lang },
                type: 'GET',
                dataType: 'json',
                success: function (data) {
                    $('#Prog_Id').empty();
                    var options = $("#Prog_Id");
                    console.log("data=", data)
                    $.each(data, function (index, result) {
                        options.append($("<option/>").val(result.Value).text(result.Text));
                    }
                    )
                }
            })
        }
    })
    $('#dtyBtn').click(function () {
        var id = $('#Prog_Id').val();
        console.log("clicked")
        if (id != 0) {
            $.ajax({
                url: '/Program/ProgramDetay',
                data: { value: id },
                type: 'GET',
                dataType: 'json',
                success: function (data) {
                    console.log(data);
                    $("#prog-table").css({ display: "block" });
                    $("#titletable").css({ display: "block" });
                    $("#info-content").addClass("border p-3");
                    $("#info-content").css({ display: "block" });
                    $("#info-content").empty();
                    $("#staff-content").addClass("border p-3");
                    $("#staff-content").css({ display: "none" });
                    $("#staff-content").empty();
                    $("#courses-content").addClass("border p-3");
                    $("#courses-content").css({ display: "none" });
                    //$("#courses-content").empty();
                    $("#admissions-content").addClass("border p-3");
                    $("#admissions-content").css({ display: "none" });
                    $("#progAdTr").empty();
                    $("#progAdEn").empty();
                    $("#progDzy").empty();
                    $("#progEABD").empty();
                    $("#progBaskan").empty();
                    $("#progAdTr").append(data.ProgramAdı)
                    $("#progAdEn").append(data.ProgramingAdı)
                    $("#progDzy").append(data.ProgramDuzey)
                    $("#progEABD").append(data.ProgramEABD)
                    $("#progBaskan").append(data.ProgramEABDBaskan)
                    if (data.ProgramDetay != "" && data.ProgramDetay != null) {
                        $("#info-content").append(data.ProgramDetay)
                    } else {
                        $("#info-content").append("Program Bilgisi Bulunamadı")
                    }
                    $('#staff-content').append('<h3>Program Koordinatörü</h3><ul id="kord"></ul>')
                    $.each(data.ProgramKadro, function (index, result) {
                        if (result.koordinator) {
                            $('#kord').append('<li>' + result.name + '</li>')
                        }
                    })
                    $('#staff-content').append('<h3>Yürütme Kurulu</h3><ul id="yurt"></ul>')
                    $.each(data.ProgramKadro, function (index, result) {
                        if (result.yurutme) {
                            $('#yurt').append('<li>' + result.name + '</li>')
                        }
                    })
                    $('#staff-content').append('<h3>Yeterlilik Kurulu</h3><ul id="yetr"></ul>')
                    $.each(data.ProgramKadro, function (index, result) {
                        if (result.yeterlilik) {
                            $('#yetr').append('<li>' + result.name + '</li>')
                        }
                    })
                    $('#staff-content').append('<h3>Akademik Kurul</h3><ul id="akadro"></ul>')
                    $.each(data.ProgramKadro, function (index, result) {
                        if ( !result.koordinator && !result.yurutme && !result.yeterlilik) {
                            $('#akadro').append('<li>' + result.name + '</li>')
                        }
                    })

                    $('#link').empty();
                    $('#link').append('<a style="color:black;"  href="https://dersprogram.sabis.sakarya.edu.tr/Program/Birim/' + data.EbsId + '" target="_blank" >' + data.dersprogramıadı + '</a >');
                    

                    $('#link1').empty();
                    $('#link1').append('<a style="color:black;" href="https://ebs.sakarya.edu.tr/Birim/DersPlan/' + data.EbsId +'" target="_blank">' + data.dersler +'</a >');

                    //Turkish
                    $('#basv-tr #donem-yil').empty();
                    $('#basv-tr #donem-yil').append(data.Basvuru_Kosul_Tr.Ogretim_Yili + ' ' + 'Öğretim Yılı' + ' '  + data.Basvuru_Kosul_Tr.Donem + '.Dönem');
                    $('#basv-tr #kontenjan').empty();
                    $('#basv-tr #kontenjan').append(data.Basvuru_Kosul_Tr.Kontenjan);
                    $('#basv-tr #yatayKontenjan').empty();
                    $('#basv-tr #yatayKontenjan').append(data.Basvuru_Kosul_Tr.Yatay_Gec_Kontenjan);
                    $('#basv-tr #lisansOrt').empty();
                    $('#basv-tr #lisansOrt').append(data.Basvuru_Kosul_Tr.Lisans_Ort);
                    $('#basv-tr #alesPuan').empty();
                    $('#basv-tr #alesPuan').append(data.Basvuru_Kosul_Tr.Min_Ales);
                    $('#basv-tr #greEski').empty();
                    $('#basv-tr #greEski').append(data.Basvuru_Kosul_Tr.GRE_Eski);
                    $('#basv-tr #greYeni').empty();
                    $('#basv-tr #greYeni').append(data.Basvuru_Kosul_Tr.GRE_Yeni);
                    $('#basv-tr #dilSart').empty();
                    $('#basv-tr #dilSart').append(data.Basvuru_Kosul_Tr.Dil_Sart);
                    $('#basv-tr #kabulEdilenProg').empty();
                    $('#basv-tr #kabulEdilenProg').append(data.Basvuru_Kosul_Tr.Kabul_Edilen_Program);

                    //Yabanci
                    $('#basv-yab #donem-yil').empty();
                    $('#basv-yab #donem-yil').append(data.Basvuru_Kos_Yab.Ogretim_Yili + ' ' + 'Öğretim Yılı' + ' ' + data.Basvuru_Kos_Yab.Donem + '.Dönem');
                    $('#basv-yab #kontenjan').empty();
                    $('#basv-yab #kontenjan').append(data.Basvuru_Kos_Yab.Kontenjan);
                    $('#basv-yab #yatayKontenjan').empty();
                    $('#basv-yab #yatayKontenjan').append(data.Basvuru_Kos_Yab.Yatay_Gec_Kontenjan);
                    $('#basv-yab #lisansOrt').empty();
                    $('#basv-yab #lisansOrt').append(data.Basvuru_Kos_Yab.Lisans_Ort);
                    $('#basv-yab #alesPuan').empty();
                    $('#basv-yab #alesPuan').append(data.Basvuru_Kos_Yab.Min_Ales);
                    $('#basv-yab #greEski').empty();
                    $('#basv-yab #greEski').append(data.Basvuru_Kos_Yab.GRE_Eski);
                    $('#basv-yab #greYeni').empty();
                    $('#basv-yab #greYeni').append(data.Basvuru_Kos_Yab.GRE_Yeni);
                    $('#basv-yab #dilSart').empty();
                    $('#basv-yab #dilSart').append(data.Basvuru_Kos_Yab.Dil_Sart);
                    $('#basv-yab #kabulEdilenProg').empty();
                    $('#basv-yab #kabulEdilenProg').append(data.Basvuru_Kos_Yab.Kabul_Edilen_Program);
                }
            })
        }
    })
    $(".info-tab-button").click(function () {
        $("#staff-content").css({ display: "none" })
        $("#courses-content").css({ display: "none" })
        $("#admissions-content").css({ display: "none" })
        $("#info-content").css({ display: "block" })
    })
    $(".staff-tab-button").click(function () {
        $("#info-content").css({ display: "none" })
        $("#courses-content").css({ display: "none" })
        $("#admissions-content").css({ display: "none" })
        $("#staff-content").css({ display: "block" })
    })
    $(".courses-tab-button").click(function () {
        $("#info-content").css({ display: "none" })
        $("#staff-content").css({ display: "none" })
        $("#admissions-content").css({ display: "none" })
        $("#courses-content").css({ display: "block" })
    })
    $(".admissions-tab-button").click(function () {
        $("#info-content").css({ display: "none" })
        $("#staff-content").css({ display: "none" })
        $("#courses-content").css({ display: "none" })
        $("#admissions-content").css({ display: "block" })
    })
})
