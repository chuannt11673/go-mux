package handler

import (
	"alt-wiki/pkg/data"
	"alt-wiki/pkg/dto"
	"encoding/json"
	"net/http"
	"strconv"

	"github.com/gorilla/mux"
)

func GetAllTodo(writer http.ResponseWriter, request *http.Request) {
	responseWithJson(writer, http.StatusOK, data.Todos)
}

func GetTodoById(writer http.ResponseWriter, request *http.Request) {
	params := mux.Vars(request)
	id, err := strconv.Atoi(params["id"])

	if err != nil {
		responseWithJson(writer, http.StatusBadRequest, map[string]string{"message": "invalid todo id"})
		return
	}

	for _, todo := range data.Todos {
		if todo.ID == id {
			responseWithJson(writer, http.StatusOK, todo)
			return
		}
	}

	responseWithJson(writer, http.StatusNotFound, map[string]string{"message": "Todo not found"})
}

func CreateTodo(writer http.ResponseWriter, request *http.Request) {
	var newTodo dto.Todo
	if err := json.NewDecoder(request.Body).Decode(&newTodo); err != nil {
		responseWithJson(writer, http.StatusNotFound, map[string]string{"message": "Invalid request body"})
	}

	newTodo.ID = generateId(data.Todos)
	data.Todos = append(data.Todos, newTodo)

	responseWithJson(writer, http.StatusOK, newTodo)
}

func UpdateTodo(writer http.ResponseWriter, request *http.Request) {
	params := mux.Vars(request)
	id, err := strconv.Atoi(params["id"])

	if err != nil {
		responseWithJson(writer, http.StatusNotFound, map[string]string{"message": "Invalid request body"})
	}

	var updatedTodo dto.Todo
	if err := json.NewDecoder(request.Body).Decode(&updatedTodo); err != nil {
		responseWithJson(writer, http.StatusNotFound, map[string]string{"message": "Invalid request body"})
		return
	}

	updatedTodo.ID = id
	for i, todo := range data.Todos {
		if todo.ID == id {
			data.Todos[i] = updatedTodo
			responseWithJson(writer, http.StatusOK, updatedTodo)
			return
		}
	}

	responseWithJson(writer, http.StatusNotFound, map[string]string{"message": "Todo not found"})
}

func DeleteTodo(writer http.ResponseWriter, request *http.Request) {
	params := mux.Vars(request)
	id, err := strconv.Atoi(params["id"])

	if err != nil {
		responseInvalidRequestBody(writer)
		return
	}

	for i, todo := range data.Todos {
		if todo.ID == id {
			data.Todos = append(data.Todos[:i], data.Todos[i+1:]...)
			responseDeleteSuccessfully(writer)
			return
		}
	}

	responseTodoNotFound(writer)
}

func responseWithJson(writer http.ResponseWriter, status int, object interface{}) {
	writer.Header().Set("Content-Type", "application/json")
	writer.WriteHeader(status)
	json.NewEncoder(writer).Encode(object)
}

func generateId(todos []dto.Todo) int {
	var maxId int
	for _, todo := range todos {
		if todo.ID > maxId {
			maxId = todo.ID
		}
	}
	return maxId + 1
}

func responseInvalidRequestBody(writer http.ResponseWriter) {
	responseWithJson(writer, http.StatusBadRequest, map[string]string{"messsage": "Invalid request body"})
}

func responseDeleteSuccessfully(writer http.ResponseWriter) {
	responseWithJson(writer, http.StatusBadRequest, map[string]string{"messsage": "Delete todo successfully"})
}

func responseTodoNotFound(writer http.ResponseWriter) {
	responseWithJson(writer, http.StatusBadRequest, map[string]string{"messsage": "Todo not found"})
}
