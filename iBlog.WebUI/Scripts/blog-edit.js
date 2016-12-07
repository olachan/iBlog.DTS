$(function () {
    $("#side-menu>li:eq(2)").addClass("active").find("ul").addClass("in").find("li:eq(2)").addClass("active");

    $(window).on("scroll", function () {
        var scrollTop = $(window).scrollTop();
        if (scrollTop > 50) {
            $("#scrollTop").show();
        } else {
            $("#scrollTop").hide();
        }
    });

    $("#scrollTop a").on("click", function () {
        $("html,body").animate({ scrollTop: 0 }, 1000);
    });

    $.ajax({
        url: "/Admin/GetCategories",
        type: "Post",
        success: function (data) {
            $("#Categorylist ul").html("");
            $.each(data, function (key, value) {
                if (value.Link == "") {
                    $("#Categorylist ul").append("<li data-value=\"" + value.Alias + "\">"
                                                    + "<a href=\"#\">" + value.CateName + "</a>"
                                                + "</li>");
                }
            });
            $("#Categorylist ul").append("<li data-value=\"other\"><a href=\"#\">未分类</a></li>");
            $("#Categorylist").selectlist("enable");
            $("#Categorylist").selectlist("selectByValue", categoryAlias);
            $("#Categorylist li[data-value=" + categoryAlias + "]").addClass("active");
        }
    });

    if (source == "1") {
        $("#soruceLink").radio("check")
    } else {
        $("#soruceLocal").radio("check")
    }

    $("#myPillbox").pillbox("addItems", 0, labels);

    var editor = UE.getEditor("editor", {
        allowDivTransToP: false,
        initialFrameHeight: 300,
        textarea: "Content"
    });

    editor.ready(function () {
        $("[data-toggle=tooltip]").tooltip({
            container: "body"
        });
    });

    $(".btn-alias").on("click", function () {

            var that = this;
            $(that).addClass("disabled");
            $.ajax({
                url: '/Admin/GetRandomName',
                type: 'get',
                dataType: 'json',
                data: {
                },
                success: function (data) {

                    $("#Alias").val(data).focus();
                },
                complete: function () {
                    $(that).removeClass("disabled");
                }
            });

    });

    $("#btnUpdate").on("click", function () {
        if ($("#postForm").valid()) {
            $.ajax({
                url: "/Admin/CheckArticleAlias",
                type: "post",
                dataType: "json",
                data: { alias: $("#Alias").val(), uid: $("#UniqueId").val() },
                success: function (data) {
                    if (data.result == true) {
                        $(this).attr("disabled", "disabled");
                        $(this).find(".fa").removeClass("fa-save").addClass("fa-circle-o-notch fa-spin");
                        $("#Labels").val(JSON.stringify($("#myPillbox").pillbox("items")));
                        $("#postForm").submit();
                    } else {
                        swal({
                            title: "alias错误！",
                            text: "请指定一个唯一的alias值",
                            type: "error",
                            showConfirmButton: false,
                            timer: 2000
                        });
                    }
                }
            });
        }
    });

    $(".selectlist").on("changed.fu.selectlist", function (e, data) {
        $(this).find("li").removeClass("active");
        $(this).find("li[data-value=" + data.value + "]").addClass("active");
    });
});

function onSuccess(data) {
    if (data === "True") {
        swal({
            title: "保存成功！",
            type: "success",
            showConfirmButton: false,
            timer: 2000
        });
    } else {
        swal({
            title: "保存失败！",
            type: "error",
            showConfirmButton: false,
            timer: 2000
        });
    }
    $("#btnUpdate").removeAttr("disabled");
    $("#btnUpdate").find(".fa").removeClass("fa-circle-o-notch fa-spin").addClass("fa-save");
}