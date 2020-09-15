format ELF64 
public _start

include "asmlib/io.inc"
include "asmlib/sys.inc"
include "asmlib/str.inc"
include "asmlib/algo.inc"


section '.data' writable
array db 5,4,3,2,1
array_size = 5

section '.text' executable
fmt db "%s%s"
first db 1
second db 2
_start:
	mov rax, array
	mov rbx, array_size
	call bubble_sort
	call print_bytes
	call exit
