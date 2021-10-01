package handler

import (
	"alt-wiki/pkg/dto"
	"context"
	"database/sql"
	"flag"
	"fmt"
	"log"
	"net/http"

	_ "github.com/denisenkom/go-mssqldb"
)

var server = "DESKTOP-545QPQM"
var port = 1433
var user = "sa"
var password = "Root@123"
var database = "GoDB"

func CheckConn(writer http.ResponseWriter, request *http.Request) {
	flag.Parse()

	connString := fmt.Sprintf("server=%s;port=%d;user id=%s;password=%s;database=%s", server, port, user, password, database)

	// create connection pool
	db, err := sql.Open("mssql", connString)

	if err != nil {
		responseWithJson(writer, http.StatusBadRequest, map[string]string{"message": "Open connection failed"})
		log.Fatal("Open connection failed", err.Error())
		return
	}

	log.Printf("Connected! \n")
	ctx := context.Background()

	// check if db is alive
	err = db.PingContext(ctx)
	if err != nil {
		log.Fatal(err.Error())
		return
	}

	// close db connection pool
	defer db.Close()
}

func GetTodosSql(writer http.ResponseWriter, request *http.Request) {
	db := GetDbConn()
	if db == nil {
		return
	}

	ctx := context.Background()
	db.PingContext(ctx)

	tsql := "SELECT ID, Name, Content FROM dbo.Todo"
	rows, err := db.QueryContext(ctx, tsql)

	if err != nil {
		return
	}

	defer rows.Close()

	var results []dto.Todo

	for rows.Next() {
		var id int
		var name, content string
		err := rows.Scan(&id, &name, &content)

		if err == nil {
			row := dto.Todo{
				ID:      id,
				Name:    name,
				Content: content,
			}
			results = append(results, row)
		}
	}

	responseWithJson(writer, http.StatusOK, results)
}

func GetDbConn() *sql.DB {
	connString := fmt.Sprintf("server=%s;port=%d;user id=%s;password=%s;database=%s", server, port, user, password, database)
	// create connection pool
	db, err := sql.Open("mssql", connString)
	if err != nil {
		return nil
	}
	return db
}
