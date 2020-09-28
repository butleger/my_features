CC=g++
CC_FLAGS=-O3 -fPIC
SRC=base_socket.cpp base_tcp_socket.cpp base_udp_socket.cpp server_tcp_socket.cpp client_tcp_socket.cpp server_udp_socket.cpp client_udp_socket.cpp
LIB_EXEC_NAME=libMySockets.so
EXEC_NAME=my_sockets.o
LIB_MAIN_NAME=Sockets


all: $(addsuffix .o, $(basename $(SRC)))
	@$(CC) $(CC_FLAGS) -o $(EXEC_NAME) $^

lib: $(addsuffix .o, $(basename $(SRC)))
	@$(CC) $(CC_FLAGS) -shared -o lib$(LIB_MAIN_NAME).so $^
%.o: %.cpp
	@$(CC) $(CC_FLAGS) -c $^
test:	test_serv.cpp test_client.cpp lib
	@$(CC) test_serv.cpp -L. -l$(LIB_MAIN_NAME) -o serv
	@$(CC) test_client.cpp -L. -l$(LIB_MAIN_NAME) -o client
clean:
	@rm $(EXEC_NAME) lib$(LIB_MAIN_NAME).so *.o serv client
