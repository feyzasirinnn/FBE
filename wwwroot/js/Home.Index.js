$(document).ready(function () {
    ToogleDisable();

    var timer, delay = 600; // 6 milisaniye sonra tetiklensin
    $('#Search').bind('keydown blur change', function (e) {
        clearTimeout(timer);
        timer = setTimeout(function () {
            LessonLoad();
        }, delay);
    });

    $("#EABD_Id").change(function () {
        var id = $(this).val();
        if (id && id > 0) {
            var programs = $("#Prog_Id");
            programs.empty();
            programs.append('<option>Seçiniz </option');
            $.ajax({
                type: "GET",
                url: '/Program/ProgramList/' + id,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {
                    $.each(data, function (index, option) {
                        faculties.append('<option value=' + option.Value + '> ' + option.Text + ' </option');
                    });
                },
                error: function (xhr, status) {
                    alert("Program yüklenemedi.");
                }
            });
        }
        ToogleDisable();
    });

 
    $("#Prog_Id").change(function () {
        DetailsLoad();
        //var id = $(this).val();
        //if (id && id > 0) {
        //    var programs = $("#ProgramId");
        //    programs.empty();
        //    programs.append('<option>Program Seçiniz </option');
        //    $.ajax({
        //        type: "GET",
        //        url: '/Home/ProgramList/' + id,
        //        contentType: 'application/json; charset=utf-8',
        //        dataType: 'json',
        //        success: function (data) {
        //            $.each(data, function (index, option) {
        //                programs.append('<option value=' + option.Value + '> ' + option.Text + ' </option');
        //            });
        //        },
        //        error: function (xhr, status) {
        //            alert("Programlar yüklenemedi.");
        //        }
        //    });
        //}
        //ToogleDisable();
    });

    
    function DetailsLoad() {
        var Prog_Id = $("#Prog_Id").val(); 
        if (Prog_Id && Prog_Id > 0) {
            $.ajax({
                type: "GET",
                url: '/Home/LessonList?DepartmentId=' + DepartmentId + "&TermId=" + TermId + "&Search=" + search,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {
                    LessonRender(data);
                },
                error: function (xhr, status) {
                    alert("Dersler yüklenemedi.");
                }
            });
        }
        ToogleDisable();
    }
    function LessonRender(data) {

        $("#tbLesson tbody").empty();
        if (data.length > 0) {
            $("#LessonTemplate").tmpl(data).appendTo("#tbLesson tbody");
        }
        else {
            $("#LessonEmpty").tmpl().appendTo("#tbLesson tbody");
        }

        var trNo = 0;
        $("#tbLesson tbody tr").each(function (i, e) {
            var no = $(e).attr("No");
            if (trNo === 0) {
                console.log("İlk yarıyıl ekleniyor");
            }
            if (no != trNo) {
                var semester = { No: no };
                $("#SemesterTemplate").tmpl(semester).insertBefore(this);
                trNo = no;
                console.log("yariyil eklendi :" + no);
            }
            else {
                console.log("yarıyıl zaten eklendi !");
            }
        });
    }
    function ToogleDisable() {

        $("#FacultyId").prop("disabled", true);
        $("#DepartmentId").prop("disabled", true);
        //$("#ProgramId").prop("disabled", true);
        $("#Message").show();
        $("#tbLesson").hide();
        $("#search").hide();

        var typeId = $("#TypeId").val();
        if (typeId && typeId > 0) {
            $("#FacultyId").prop("disabled", false);
            var FacultyId = $("#FacultyId").val();
            if (FacultyId && FacultyId > 0) {
                $("#DepartmentId").prop("disabled", false);
                var DepartmentId = $("#DepartmentId").val();
                if (DepartmentId && DepartmentId > 0) {
                    //$("#ProgramId").prop("disabled", false);
                    //var ProgramId = $("#ProgramId").val();
                    //if (ProgramId && ProgramId > 0) {

                    //}
                    var TermId = $("#TermId").val();
                    if (TermId && TermId > 0) {
                        $("#Message").hide();
                        $("#tbLesson").show();
                        $("#search").show();
                    }
                }
                else {
                    $("#ProgramId").empty();
                    $("#ProgramId").append('<option>Program Seçiniz </option');
                }

            }
            else {
                $("#DepartmentId").empty();
                $("#DepartmentId").append('<option>Bölüm Seçiniz </option');
                //$("#ProgramId").empty();
                //$("#ProgramId").append('<option>Program Seçiniz </option');
            }
        }
        else {
            $("#FacultyId").empty();
            $("#FacultyId").append('<option>Fakülte Seçiniz </option');
            $("#DepartmentId").empty();
            $("#DepartmentId").append('<option>Bölüm Seçiniz </option');
            //$("#ProgramId").empty();
            //$("#ProgramId").append('<option>Program Seçiniz </option');
        }
    }
});