package main

import (
	"alt-wiki/pkg/handler"
	"log"
	"net/http"

	"github.com/gorilla/mux"
)

func main() {
	r := mux.NewRouter()

	r.HandleFunc("/api/todo", handler.GetAllTodo).Methods(http.MethodGet)
	r.HandleFunc("/api/todo/{id}", handler.GetTodoById).Methods(http.MethodGet)
	r.HandleFunc("/api/todo", handler.CreateTodo).Methods(http.MethodPost)
	r.HandleFunc("/api/todo/{id}", handler.UpdateTodo).Methods(http.MethodPut)
	r.HandleFunc("/api/todo/{id}", handler.DeleteTodo).Methods(http.MethodDelete)

	r.HandleFunc("/api/todo-sql/check", handler.CheckConn).Methods(http.MethodGet)
	r.HandleFunc("/api/todo-sql", handler.GetTodosSql).Methods(http.MethodGet)

	log.Fatal(http.ListenAndServe(":8080", r))
}
