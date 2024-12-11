document.getElementById("betoltButton").addEventListener("click", () => {
    let betoltendo = document.getElementById("betoltId").value;
    fetch(`api/sudoku/${betoltendo}`, {
        method: 'GET'
    }).then(response => {
        if (!response.ok) {
            throw new Error("Hiba történt a sudoku betöltésekor.");
        }
        return response.json();
    }).then(o => {
        var tabla = document.getElementById("tb_sudoku");
        
        tabla.innerHTML = "";

        for (var i = 0; i < 9; i++) {
            var sor = document.createElement("tr");
            for (var j = 0; j < 9; j++) {
                var cella = document.createElement("td");
                cella.setAttribute("id", `cell_${i + 1}_${j + 1}`);
                if (o.grid[j + i * 9] != 0) {
                    cella.textContent = o.grid[j + i * 9];
                }
                else {
                    cella.textContent = "";
                }
                sor.appendChild(cella);
            }
            tabla.appendChild(sor);
        }
    }).catch(error => {
        console.error("Error:", error);
    });
});

var cells = document.querySelectorAll('[id^="cell_"]');

cells.forEach(function (cell) {
    cell.addEventListener("mouseover", () => {
        cell.style.backgroundColor = "#f0f0f0";
    });
    cell.addEventListener("mouseout", () => {
        cell.style.backgroundColor = "";
    });
});

document.getElementById("deleteButton").addEventListener("click", () => {
    let torlendo = document.getElementById("deleteId").value;
    fetch(`api/sudoku/${torlendo}`, {
        method: 'DELETE'
    }).then(x => {
        if (x.ok) {
            alert("Siker");
            location.reload();
        }
        else {
            alert("Hiba");
        }
    });
});

document.getElementById("new").addEventListener("click", _ => {
    var sudokuData = {
        "name": document.getElementById("name").value,
        "grid": document.getElementById("racs").value,
        "difficultyLevel": document.getElementById("nehezseg").value,
        "dateCreated": document.getElementById("letrehozasIdeje").value,
    }
    fetch("api/sudoku", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(sudokuData)
    }).then(v => {
        if (v.ok) {
            alert("Siker")
            location.reload();
        }
        else {
            alert("Hibásan vannak megadva az adatok!")
        }
    })
})

fetch("api/sudoku").then(v => v.json()).then(o => {
    var tabla = document.getElementById("tb_hp");
    for (var i = 0; i < o.length; i++) {
        var sor = document.createElement("tr");
        sor.innerHTML = `
                    <td> ${o[i].puzzleId}</td>
                    <td> ${o[i].name}</td>
                    <td> ${o[i].grid}</td>
                    <td> ${o[i].difficultyLevel}</td>
                    <td> ${o[i].dateCreated}</td>
                    <td> ${o[i].solutions}</td>
                    `;
        tabla.appendChild(sor);
    }
})