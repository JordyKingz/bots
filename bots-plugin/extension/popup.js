document.addEventListener('DOMContentLoaded', function() {
  var checkPageButton = document.getElementById('checkPage');
  checkPageButton.addEventListener('click', function() {

    chrome.tabs.getSelected(null, function(tab) {
      d = document;

      $.post( "http://peterschriever.com/api/v1/legal-text-check", function( result ) {

        var safe = result.categoriesTotal - result.data.length;
        var notable = 0;
        var hazard = 0;

        var weights = {};
        $.each(result.data,function(index, value){
          weights[value.name] = 0;
          $.each(value.problems,function(k, v){
            weights[value.name] = v.weight > weights[value.name] ? v.weight : weights[value.name];

          });
        });

        $.each(weights,function(index, value){
          if(value >= 66){
            hazard+=1;
          }
          else{
            notable+=1;
          }
        });
        // alert(JSON.stringify({safe, notable, hazard}));

      var labels = [
        "Veilig",
        "Risicovol",
        "Opvallend",
      ]


      safe = ((safe / 12) * 100).toFixed(1);
      notable = ((notable / 12) * 100).toFixed(1);
      hazard = ((hazard / 12) * 100).toFixed(1);
      var status = [safe, hazard, notable];



      var description = $.map(result.data, function(category) {
        // return category.paragraphs;
        // var par = '';
        var par = {};
        par[category.name] = $.map(category.problems, function(problem) {
          return problem.msg;
        //
        });
        return par;
      });

      var data = {
        datasets: [
        {
          label: labels,
          data: status
        }
        ]
      };


      var pars = $.map(result.data, function(paragraphs) {
        $.each(paragraphs, function(paragraph){
          // alert(JSON.stringify(paragraph.text));
        })
      });



      $.each(description, function(index, cats) {
        $.each(cats, function(index, value) {
          $.each(value, function(problem, item) {
              // alert(problem + ":" + JSON.stringify(item));
          });
        });
      });

    $.each(result.data, function(index, category) {
      $.each(category.paragraphs, function(ind, paragraph) {
        // paragraphState = "danger" or "warning" or "success"
        if (paragraph.weight > 66) {
          paragraphState = "danger";
        } else if (paragraph.weight < 66 && paragraph.weight > 0) {
          paragraphState = "warning";
        } else {
          paragraphState = "success";
        }

        var child = '<div class="row"><div class="col-md-12"><div class="alert alert-'+paragraphState+'"><p><strong>'+category.name+'</strong></p><p>'+paragraph.text+'</p></div></div></div>';
        $('#description').append(child);
      });
    });


      // $("#description").append(JSON.stringify(description));

      // toggle display elements
      $('.button-tos').toggle();

      var ctx = document.getElementById("myChart");

      $('#result').toggle();

        $("#app").addClass("app-result");

      var myChart = new Chart(ctx, {
        type: 'pie',
        data: {
            labels: labels,
            datasets: [{
                label: '# of Votes',
                data: status,
                backgroundColor: [
                    'rgba(76, 161, 44, 0.8)',
                    'rgba(191, 17, 13, 0.8)',
                    'rgba(232, 105, 0, 0.8)'
                ],
                borderColor: [
                    'rgba(75, 192, 192, 1)',
                    'rgba(255,99,132,1)',
                    'rgba(255, 159, 64, 1)'
                ],
                borderWidth: 1
            }]
        },
    });


    });
      // d.body.innerHTML = 'iets';
      // f.submit();
    });
  }, false);
}, false);
