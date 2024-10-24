const http = "http://srv-dev-test:4001/Home/";

$(function () {

    $("#connexion").attr('hidden', true);
    $("#deConnexion").attr('hidden', false);

    $("#submitLogin").click(function () {
        authentification();
    });
});

function authentification() {

    var utilisateur = {};
    var data_retour = {};
    var page_actuelle = 0;   

    var varCheckUserMatricule = localStorage.getItem("checkUserMatricule");
    var varExiste = false;

    var usermatricule = localStorage.getItem("usermatricule");
    if (usermatricule != null) {
        usermatricule = "";
        localStorage.removeItem("usermatricule");
    }

    utilisateur.matricule = $("#matricule").val();

    

    $.ajax({
        type: 'POST',
        //url: '@Url.Action("ConnexionUtilisateur","Home")',
        url: http + 'ConnexionUtilisateur',
        dataType: "json",
        data: utilisateur,
        success: function (response) {
            var _service = response;

            if (_service.oneData == null) {

                $("#matricule").val('');

                DevExpress.ui.notify({
                    message: "Entrer correctement, votre matricule !",
                    position: {
                        my: "center top",
                        at: "right top"
                    }
                }, "error", 6000)

            }

            if (_service.oneData != null && _service.connexion) {

                $("#matricule").val('');
                DevExpress.ui.notify({
                    message: "ce matricule à déjà repondu à toutes les questions !",
                    position: {
                        my: "center top",
                        at: "right top"
                    }
                }, "error", 6000)
            }
        
            if (_service.oneData != null && varCheckUserMatricule != _service.oneData.matricule) {

                $("#matricule").val('');
                varExiste = true;
                DevExpress.ui.notify({
                    message: "Désole vous n'êtes pas identifié a ce matricule !",
                    position: {
                        my: "center top",
                        at: "right top"
                    }
                }, "error", 6000)
            }



            if (_service.oneData != null && !_service.connexion && varExiste == false) {

                localStorage.setItem("usermatricule", _service.oneData.matricule);

                $.ajax({
                    'async': false,
                    'global': false,
                    'type': 'GET',                   
                    'url': http + 'ListeCocherTampon' + "?matricule=" + _service.oneData.matricule,
                    'dataType': "json",
                    'success': function (response_3) {                       
                    var nbre = response_3.data.length;
                      
                        if (nbre > 0) {
                                                 

                                $.ajax({
                                'async': false,
                                'global': false,
                                'type': 'GET',                               
                                'url': http + 'ListeCocherTamponByPage' + "?matricule=" + _service.oneData.matricule + '&page=' + response_3.data[0].page,
                                'dataType': "json",
                                'success': function (response_4) {
                               
                                var nbre_4 = response_4.data.length;                                   
                                   
                                 
                                    if (nbre_4 > 0) {                                    
                                        

                                        data_retour = retourne_numero_page(response_4.data[response_4.data.length - 1].nbreChoixRestant, response_4.data[0].page);

                                       if (data_retour.page !== response_4.data[0].page) {
                                          
                                            page_actuelle = data_retour.page;
                                            nbre_4 = data_retour.nbreChoix;

                                        } else {                                           
                                            page_actuelle = response_4.data[0].page;
                                        }


                                            


                                             $.ajax({
                                            'async': false,
                                            'global': false,
                                            'type': 'GET',
                                            // 'url': '@Url.Action("ChoixLotSousQuestions", "Home")' + "?page_entre=" + response_3.data[0].page,
                                            'url': http + 'ChoixLotSousQuestions' + "?page_entre=" + page_actuelle,
                                            'dataType': "json",
                                            'success': function (response) {
                                                  
                                                     var id = 0;                                                  
                                                     if (response_4.data[0].position == response_4.data.length && response_4.data[0].nbreChoixRestant == 1 ) {
                                                         id = 1;
                                                     } else {                                                       
                                                         id = response_4.data[0].position + 1
                                                     }
                                             
                                                //----- Lot d'ingrémentation des sous questions   ---------

                                                $.ajax({
                                                    'async': false,
                                                    'global': false,
                                                    'type': 'GET',
                                                    //'url': '@Url.Action("ChoixSousQuestion", "Home")' + "?numero=" + response_3.data[0].position + "&questionid=" + response_3.data[0].questionId,
                                                    //'url': http + 'ChoixSousQuestion' + "?numero=" + response_4.data[0].position + "&questionid=" + response_4.data[0].questionId,
                                                    'url': http + 'ChoixSousQuestion' + "?numero=" + id + "&questionid=" + page_actuelle,
                                                    'dataType': "json",
                                                    'success': function (response_2) {
                                                      
                                                     
                                                        // var url = '@Url.Action("SousQuestion", "Home")' + "?page=" + response.oneData.page + "&id=" + response_3.data[0].position + "&nbreChoix=" + response.oneData.nbreChoix;
                                                     
                                                        var position_choix = response_4.data[0].nbreChoixRestant - 1;
                                                        if (position_choix == 0) {
                                                            position_choix = data_retour.nbreChoix;
                                                        }
                                                     
                                                        var url = http + 'SousQuestion' + "?page=" + page_actuelle + "&id=" + id + "&nbreChoix=" + position_choix;

                                                        window.location.href = url;
                                                    }
                                                });
                                                //--- End Lot d'ingrémentation des sous questions ---------


                                            }
                                        });




                                    }

                                }


                            });




                        } else {


                            $.ajax({
                                'async': false,
                                'global': false,
                                'type': 'GET',
                                // 'url': '@Url.Action("LotSousQuestions", "Home")',
                                'url': http + 'LotSousQuestions',
                                'dataType': "json",
                                'success': function (response) {

                                    //----- Lot d'ingrémentation des sous questions   ---------

                                    $.ajax({
                                        'async': false,
                                        'global': false,
                                        'type': 'GET',
                                        // 'url': '@Url.Action("ChoixSousQuestion", "Home")' + "?numero=" + response.data[0].id + "&questionid=" + response.data[0].page,
                                        'url': http + 'ChoixSousQuestion' + "?numero=" + response.data[0].id + "&questionid=" + response.data[0].page,
                                        'dataType': "json",
                                        'success': function (response_2) {
                                            var _question = response_2.oneData.numero_Sous_Question;
                                            // var url = '@Url.Action("SousQuestion", "Home")' + "?page=" + response.data[0].page + "&id=" + _question + "&nbreChoix=" + response.data[0].nbreChoix;
                                            var url = http + 'SousQuestion' + "?page=" + response.data[0].page + "&id=" + _question + "&nbreChoix=" + response.data[0].nbreChoix;

                                            window.location.href = url;
                                        }
                                    });
                                    //--- End Lot d'ingrémentation des sous questions ---------


                                }
                            });



                        }
                    },
                    error: function (data) {
                        console.log(data);
                    }
                });

            }

        },
        error: function (request, status, error) {
            console.log("j'ai trouvé une erreur : " + request.responseText);
        }

    });

}



 function retourne_numero_page(_nbre, _page) {
     debugger;
     var data = {};

    $.ajax({
        'async': false,
        'global': false,
        'type': 'GET',     
        'url': http + 'LotSousQuestions',
        'dataType': "json",
        'success': function (response) {
          
            

            if (_page == 1 && _nbre == 5) {
                data = response.data.find(({ page }) => page == 1); 
                return;
            }
            if (_page == 2 && _nbre == 5) {
                
                data = response.data.find(({page}) => page == 2); 
                return;
            }

            if (_page == 3 && _nbre == 7) {
                
                data = response.data.find(({ page }) => page == 3); 
                return;
            } 

            if (_page == 4 && _nbre == 5) {
                data = response.data.find(({ page }) => page == 4); 
                return;
            } 

            if (_page == 5 && _nbre == 6) {
                data = response.data.find(({ page }) => page == 5); 
                return;
            } 





            //if (_page == 6 && _nbre == 4) {
            //    data = response.data[_page];
            //    return;
            //} 

            //if (_page == 7 && _nbre == 8) {
            //    data = response.data[_page];
            //    return;
            //} 

           
            //if (_page == 8 && _nbre == 4) {
            //    data = response.data[_page];
            //    return;
            //} 
            //if (_page == 9 && _nbre == 6) {
            //    data = response.data[_page];
            //    return;
            //} 

        

          /*  if (_page !== 1 || _page !== 2 || _page !== 2 || _page !== 3 || _page !== 4 || _page !== 5 || _page !== 6 || _page !== 7 || _page !== 8 || _page !== 9) {

                data = {
                    Id: 0,
                    page: _page,
                    nbreChoix: _nbre + 1
                }
               // data = response.data[_page];
                return;
            } */



          

        }
    });
    
     return data;

}
