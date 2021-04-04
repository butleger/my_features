.PHONY: main all link libs clean
CC=fasm
CFLAGS= $()
LD = ld 
LDFLAGS = $()

LIB_DIR = asmlib# path to libs
MAIN_FILE = main.asm
EXEC_NAME = $(basename $(MAIN_FILE)) # remove extension from MAIN_FILE

LIB_SRC = $(addprefix $(LIB_DIR)/, math.asm io.asm sys.asm str.asm algo.asm)
LIB_OBJ = $(addsuffix .o, $(basename $(LIB_SRC))) # just make variable with only library objects
DYN_LIB_NAME = libass.so
STATIC_LIB_NAME = bigass.a
STATIC_LIB_MAKER = ar

OBJ = $(addsuffix .o, $(basename $(LIB_SRC) $(MAIN_FILE))) # all object files(including libs and main)


all: link # run main file
	@./$(EXEC_NAME)

dynamic_lib: libs
	$(LD) $(LD_FLAGS) -shared $(LIB_OBJ) -o $(DYN_LIB_NAME)

static_lib: libs
	$(STATIC_LIB_MAKER) -r $(STATIC_LIB_NAME) $(LIB_OBJ)

link: main libs 
	@$(LD) $(LD_FLAGS) $(OBJ) -o $(EXEC_NAME)

main: $(MAIN_FILE)
	@$(CC) $(CFLAGS) $(MAIN_FILE)

libs: # use libs own Makefile
	@make -C $(LIB_DIR)

clean:
	@rm *.o $(EXEC_NAME) $(STATIC_LIB_NAME)
	@make clean -C $(LIB_DIR) # use libs own "make clean"
