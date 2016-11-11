document.addEventListener('DOMContentLoaded', function() {
  var checkPageButton = document.getElementById('checkPage');
  checkPageButton.addEventListener('click', function() {

    chrome.tabs.getSelected(null, function(tab) {
      d = document;

      // var f = d.createElement('form');
      // f.action = 'http://peterschriever.com/api/v1/legal-text-check';
      // f.method = 'post';
      // var i = d.createElement('input');
      // i.type = 'hidden';
      // i.name = 'url';
      // i.value = tab.url;
      // f.appendChild(i);
      // maak grafiek met f
      // d.body.appendChild(d.body.innerHTML = 'test');
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
        alert(JSON.stringify({safe, notable, hazard}));


      // will generate array with ['Monday', 'Tuesday', 'Wednesday']
      alert(JSON.stringify(result));
      var labels = [
        "Veilig",
        "Risicovol",
        "Opvallend",
      ]

      // $.map(result.data, function(category) {
      //   return category.name;
      // });
      // alert(JSON.stringify(labels));

      safe = ((safe / 12) * 100).toFixed(1);
      notable = ((notable / 12) * 100).toFixed(1);
      hazard = ((hazard / 12) * 100).toFixed(1);
      var status = [safe, hazard, notable];

      // $.map(result.data, function(category) {
      //   // weight
      //   // loop through problems
      //   let largestProbl = 0;
      //   $.map(category.paragraphs, function(paragraph) {
      //     if (paragraph.weight > 66) {
      //       // largestProbl = paragraph.weight;
      //       hazard += 1;
      //       return true;
      //     }
      //     if (paragraph.weight > 0) {
      //       notable += 1;
      //     }
      //   });
      //   return largestProbl;
      // });
      alert(JSON.stringify(status));

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
                    'rgba(75, 192, 192, 0.2)',
                    'rgba(255, 99, 132, 0.2)',
                    'rgba(255, 159, 64, 0.2)'
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
