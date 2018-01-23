
$(document).ready(function () {

    $("#boxSemResultado").hide();
    ActiveMenu("#tab1")
    var EmailAtual = localStorage.getItem("EmailAtual");
    if (localStorage.getItem("EmailAtual") != null && localStorage.getItem("EmailAtual") != "") {
        //$('.nav-tabs a[href=""]').tab('show');
        ActiveMenu("#tab2")
    }


    $("#btnVoltar").bind("click", function () {
        //$('.nav-tabs a[href="#tab2"]').tab('show');
        ActiveMenu("#tab2")
    })


    $("#btnSendEmail").bind("click", function () {

        var btn = $(this).button('loading');
        var data = { email: $("#Email").val() }



        if (data.email == "") {
            btn.button('reset');
            alert("Prencha o Email");
            return false;
        }

        $.ajax({
            type: "POST",
            url: "/User/VerifyIfEmailAlreadyExists/",
            data: JSON.stringify(data),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
            },
            success: function (result) {
                btn.button('reset');
                if (result.result == 0) {

                    alert(result.msg);

                } else if (result.result == 1) {

                    ActiveMenu("#tab4");

                } else {

                    localStorage.setItem("Email", data.email);
                    EmailAtual = data.email;
                    ActiveMenu("#tab2");

                }

            }
        });

    })

    $("#btnSendUser").bind("click", function () {

        var btn = $(this).button('loading');
        var data = { name: $("#Name").val(), email: $("#Email").val(), teamId: $("#Teams").val() }



        if (data.name == "") {
            btn.button('reset');
            alert("Prencha o Nome");
            return false;
        }

        if (data.teamId == "") {
            btn.button('reset');
            alert("Seleciona a Equipe");
            return false;
        }

        $.ajax({
            type: "POST",
            url: "/User/AddNewUser/",
            data: JSON.stringify(data),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
            },
            success: function (result) {
                btn.button('reset');
                if (result.result != "OK") {
                    alert(result.result);
                } else {
                    ActiveMenu("#tab2");
                }

            }
        });

    })



    $("#btnEnviarVoto").bind("click", function () {
        var btn = $(this).button('loading');
        var selectedDayOfWeek = $("#box-day-of-week input:checked").val();
        var selectedRestaurant = $("#box-restaurants input:checked").val();

        if (!selectedDayOfWeek) {
            alert("Selecione o Dia da Semana!");
            btn.button('reset');
            return false;
        }


        if (selectedDayOfWeek != new Date().getDay()) {

            if (selectedDayOfWeek > new Date().getDay()) {
                alert("Calma aí, cada dia sua votação! Escolha um restaurante para hoje!");
            } else {
                alert("Tarde demais, " + $("#box-day-of-week input:checked").next().text() + " já passou!");
            }

            btn.button('reset');
            return false;
        }

        if (!selectedRestaurant) {
            alert("Selecione o Restaurante!");
            btn.button('reset');
            return false;
        }

        var data = { dayOfWeek: selectedDayOfWeek, email: localStorage.getItem("EmailAtual"), restaurantId: selectedRestaurant }

        $.ajax({
            type: "POST",
            url: "/Voting/Add/",
            data: JSON.stringify(data),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                btn.button('reset');
                alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
            },
            success: function (result) {
                if (result.msg == "OK") {
                    ExibirResultado(data.dayOfWeek)
                } else {
                    alert(result.msg);
                }
                btn.button('reset');
            }
        });

    })

    $(".btnVerResultado").bind("click", function () {
        var btn = $(this).button('loading');

        if (!$("#box-day-of-week input:checked").val()) {
            alert("Selecione o Dia da Semana!");
            btn.button('reset');
            return false;
        }

        ExibirResultado($("#box-day-of-week input:checked").val());
        btn.button('reset');
    })

    $("#linkSair").bind("click", function () {
        localStorage.clear();
        ActiveMenu("#tab1");
    })



});


function ActiveMenu(active) {

    $('.nav-tabs a[href=' + active + ']').tab('show');

}

function ExibirResultado(dayOfWeek) {

    var data = { dayOfWeek: dayOfWeek }

    $.ajax({
        type: "POST",
        url: "/Voting/ShowResult",
        data: JSON.stringify(data),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (result) {
            console.log(result);
            //var ret = result.d;
            //console.log(ret);
            //if (ret.result) {

                //$('.nav-tabs a[href="#tab3"]').tab('show');
                ActiveMenu("#tab3")

                //if (ret.msg == "") {

                    $("#boxResultado").show();
                    $("#boxSemResultado").hide();
                    //console.log(ret.msg);
                    //var json = JSON.parse(ret.json);
                    $("#lblRestauranteVencedor").text(result.Restaurant.Name);
                    $("#lblQtdVotos").text(result.Qty);
                    if (new Date().getDay() == dayOfWeek) {
                        $("#lblDiaSemana").text("Hoje");
                    } else {
                        $("#lblDiaSemana").text($("#box-day-of-week input:checked").parent().text().trim());
                    }

            //    } else {
            //        $("#boxResultado").hide();
            //        $("#boxSemResultado").show();
            //    }


            //} else {
            //    alert(ret.msg);
            //}
        }
    });

}