$(document).ready(function () {

    url = "http://gestabsence.sucafci.lan/Direction/listes/";
    
    var t = compteur();


    if (t > 0) {
        $("#attente").text(t);
    } else {
        $(".badge-danger").hide();
    }
 
   

});




/*select records from table*/
function compteur() {
    var somme = 0;
   
    level = $('.level').attr('id');

    somme = (function () {
        var json = null;
        var nbr = 0;
        if (level == "2")
        {
            direction = $('.dir').attr('id');
           somme = Validation(direction);
        }
        if (level == "3")
        {
            $.ajax({
                'async': false,
                'global': false,
                'url': "http://gestabsence.sucafci.lan/Direction/listes/",
                'dataType': "json",
                'success': function (data) {
                    console.log(data);

                    $.each(data, function (index, item) {
                        nbr = Validation(item.IDDIRECTION);

                        if (nbr > 0) {

                            somme += nbr;

                        }

                    });

                }
            });
        }
        if (level == "5")
        {
            $.ajax({
                'async': false,
                'global': false,
                'url': "http://gestabsence.sucafci.lan/Direction/listes/",
                'dataType': "json",
                'success': function (data) {
                    console.log(data);

                    $.each(data, function (index, item) {
                        nbr = Validation(item.IDDIRECTION);

                        if (nbr > 0) {

                            somme += nbr;

                        }

                    });

                }
            });
        }
        

        return somme;

    })();

    return somme;
}


function Validation(direction) {
    var json = null;
    var urlCompte = null;
    level = $('.level').attr('id');
    if (level == "2") { urlCompte = "http://gestabsence.sucafci.lan/Employe/CompteDirectionEnAttente/";}
    if (level == "3") { urlCompte = "http://gestabsence.sucafci.lan/Employe/CompteDafEnAttente/"; }
    if (level == "5") { urlCompte = "http://gestabsence.sucafci.lan/Employe/CompteDgaEnAttente/"; }
    today = new Date();
    annee = today.getFullYear() + 1;
    //console.log("level");
    //console.log(level);
    $.ajax({
        'async': false,
        'global': false,
        'data': { annee: annee, direction: direction },
        'url': urlCompte,
        'dataType': "json",
        'success': function (data) {
            json = data;

        }
    });

    return json;
};

