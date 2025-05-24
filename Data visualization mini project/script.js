//Chart margins and dimensions
const margin = {top: 20, right: 30, bottom: 50, left: 60},
      width = 900 - margin.left - margin.right,
      height = 500 - margin.top - margin.bottom;

const svgBar = d3.select("#barChart").append("g").attr("transform", `translate(${margin.left},${margin.top})`);
const svgScatter = d3.select("#scatterPlot").append("g").attr("transform", `translate(${margin.left},${margin.top})`);

const tooltip = d3.select("#tooltip");

d3.csv("students_performance_subset.csv").then(data => {
    // Convert scores to numerical values
    data.forEach(d => {
        d["math score"] = +d["math score"];
        d["reading score"] = +d["reading score"];
    });

    // Updating both charts
    function updateCharts(filteredData) {
        svgBar.selectAll("*").remove();
        svgScatter.selectAll("*").remove();

        //Average math and reading scores by race
        const avgByRace = d3.rollups(filteredData, 
            v => ({
                math: d3.mean(v, d => d["math score"]),
                reading: d3.mean(v, d => d["reading score"])
            }), 
            d => d["race/ethnicity"]
        );

        const xBar = d3.scaleBand().domain(avgByRace.map(d => d[0])).range([0, width]).padding(0.2);
        const yBar = d3.scaleLinear().domain([0, d3.max(avgByRace, d => Math.max(d[1].math, d[1].reading))]).range([height, 0]);

        //Add X and Y axes
        svgBar.append("g").attr("transform", `translate(0,${height})`).call(d3.axisBottom(xBar));
        svgBar.append("g").call(d3.axisLeft(yBar));

        // Add axis labels for the bar chart
        svgBar.append("text")
            .attr("x", width / 2)
            .attr("y", height + margin.bottom - 10)
            .attr("text-anchor", "middle")
            .text("Race/Ethnicity");

        svgBar.append("text")
            .attr("transform", "rotate(-90)")
            .attr("x", -height / 2)
            .attr("y", -margin.left + 15)
            .attr("text-anchor", "middle")
            .text("Average Scores");

        //Bars for math scores
        svgBar.selectAll(".bar-math")
            .data(avgByRace)
            .enter().append("rect")
            .attr("class", "bar-math")
            .attr("x", d => xBar(d[0]))
            .attr("width", xBar.bandwidth() / 2)
            .attr("y", d => yBar(d[1].math))
            .attr("height", d => height - yBar(d[1].math))
            .attr("fill", "steelblue")
            .on("mouseover", (event, d) => {
                tooltip.transition().style("opacity", 0.9);
                tooltip.html(`Race: ${d[0]}<br>Avg Math: ${d[1].math.toFixed(1)}<br>Avg Reading: ${d[1].reading.toFixed(1)}`)
                       .style("left", (event.pageX + 5) + "px")
                       .style("top", (event.pageY - 28) + "px");
            })
            .on("mouseout", () => tooltip.transition().style("opacity", 0));

        //Bars for reading scores
        svgBar.selectAll(".bar-reading")
            .data(avgByRace)
            .enter().append("rect")
            .attr("class", "bar-reading")
            .attr("x", d => xBar(d[0]) + xBar.bandwidth() / 2)
            .attr("width", xBar.bandwidth() / 2)
            .attr("y", d => yBar(d[1].reading))
            .attr("height", d => height - yBar(d[1].reading))
            .attr("fill", "orange");

        // SCATTER PLOT
        const xScatter = d3.scaleLinear().domain([0, 100]).range([0, width]);
        const yScatter = d3.scaleLinear().domain([0, 100]).range([height, 0]);

        //X and Y axes
        svgScatter.append("g").attr("transform", `translate(0,${height})`).call(d3.axisBottom(xScatter));
        svgScatter.append("g").call(d3.axisLeft(yScatter));

        // Add axis labels for the scatter plot
        svgScatter.append("text")
            .attr("x", width / 2)
            .attr("y", height + margin.bottom - 10)
            .attr("text-anchor", "middle")
            .text("Math Score");

        svgScatter.append("text")
            .attr("transform", "rotate(-90)")
            .attr("x", -height / 2)
            .attr("y", -margin.left + 15)
            .attr("text-anchor", "middle")
            .text("Reading Score");

        //Circles
        const colorScale = d3.scaleOrdinal().domain(["male", "female"]).range(["teal", "purple"]);

        svgScatter.selectAll("circle")
            .data(filteredData)
            .enter().append("circle")
            .attr("cx", d => xScatter(d["math score"]))
            .attr("cy", d => yScatter(d["reading score"]))
            .attr("r", 4)
            .attr("fill", d => colorScale(d.gender))
            .on("mouseover", (event, d) => {
                tooltip.transition().style("opacity", 0.9);
                tooltip.html(`Gender: ${d.gender}<br>Math: ${d["math score"]}<br>Reading: ${d["reading score"]}`)
                       .style("left", (event.pageX + 5) + "px")
                       .style("top", (event.pageY - 28) + "px");
            })
            .on("mouseout", () => tooltip.transition().style("opacity", 0));

        // Add legend for scatter plot
        const legend = svgScatter.append("g").attr("transform", `translate(${width - 100}, 20)`);

        legend.selectAll("rect")
            .data(colorScale.domain())
            .enter().append("rect")
            .attr("x", 0)
            .attr("y", (d, i) => i * 20)
            .attr("width", 10)
            .attr("height", 10)
            .attr("fill", d => colorScale(d));

        legend.selectAll("text")
            .data(colorScale.domain())
            .enter().append("text")
            .attr("x", 15)
            .attr("y", (d, i) => i * 20 + 9)
            .text(d => d)
            .attr("font-size", "12px")
            .attr("fill", "black");
    }

    //Filter by gender
    d3.select("#genderFilter").on("change", function () {
        const gender = this.value;
        const filter = gender === "All" ? data : data.filter(d => d.gender === gender);
        updateCharts(filter);
    });

    updateCharts(data);
});
