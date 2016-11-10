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
      $.post( "http://peterschriever.com/api/v1/csharp-legal-text-check", function( result ) {
      // will generate array with ['Monday', 'Tuesday', 'Wednesday']
      var labels = $.map(result.data, function(category) {
        return category.name;
      });
      // alert(JSON.stringify(labels));
      var status = $.map(result.data, function(category) {
        // weight
        // loop through problems
        let largestProbl = 0;
        $.map(category.problems, function(problem) {
          if (problem.weight > largestProbl) {
            largestProbl = problem.weight;
          }
        });
        return largestProbl;
      });
      // alert(JSON.stringify(status));

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

      // alert(JSON.stringify(description));

      $.each(description, function(index, cats) {
        $.each(cats, function(index, value) {

          // alert(index + ":" + JSON.stringify(value));
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
                    'rgba(255, 99, 132, 0.2)',
                    'rgba(75, 192, 192, 0.2)',
                    'rgba(255, 159, 64, 0.2)'
                ],
                borderColor: [
                    'rgba(255,99,132,1)',
                    'rgba(75, 192, 192, 1)',
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
