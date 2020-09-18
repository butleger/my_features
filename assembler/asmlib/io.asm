format ELF64

public endl
public printf
public print_abcd
public print_char
public print_bytes
public input_string
public input_number
public print_string
public print_number
public print_string_without_endl

include "str.inc"
include "macro.m"

section '.bss' writable
	_buffer_size equ 22
	_buffer_for_number rb _buffer_size
	bss_char rb 1


section '.input_number' executable
; |output:
;	rax = number
input_number:
	push rbx
	mov rax, _buffer_for_number
	mov rbx, _buffer_size
	call input_string
	call strlen
	mov rbx, _buffer_for_number
	mov [rbx + rax - 1],byte 0
	mov rax, _buffer_for_number
	call string_to_number
	pop rbx
	ret


section '.input_string' executable
; |input:
;	rax = buffer
;	rbx = buffer size
input_string:
	push_abcd
	mov rdx, rbx
	mov rcx, rax
	mov rax, 3; input interruption
	mov rbx, 2; stdin
	int 0x80
	mov [rcx + rax + 1], byte 0
	pop_dcba
	ret

section '.printf' executable
;|input;
;	rax = string(format)
;	stack = values
printf:
	push_abcd
	push rbp
	mov rbp, rsp

	.next_iter:
		mov rbp, 16
		cmp [rax], byte 0
		je .close
		cmp [rax],byte '%'
		je .special_char
		jmp .default_char
		.special_char:
			inc rax
			cmp [rax], byte 's'
			je .print_string
			.print_string:
				push rax
				mov rax, [rsp + rbx]
				pop rax
				inc rax
				jmp .shift_stack
		.default_char:
			push rax
			mov rax, [rax]
			call print_char
			pop rax	
			inc rax
			jmp .next_step
		.shift_stack:
			add rbx, 8
		.next_step:
			jmp .next_iter
	.close:
		pop rbp
		pop_dcba
		ret


section '.print_number' executable
;| input
;rax = number
print_number:
	push_abcd

	xor rcx, rcx

	.next_iter:
		mov rbx, 10
		xor rdx, rdx
		div rbx
		add rdx, '0'
		push rdx
		inc rcx
		cmp rax, 0
		je .print_iter
		jmp .next_iter
	
	.print_iter:
		cmp rcx, 0
		je .return
		pop rax
		call print_char
		dec rcx
		jmp .print_iter

	.return:
		pop_dcba		
		ret


section '.print_abcd'
str_a db "a = ", 0
str_b db "b = ", 0
str_c db "c = ", 0
str_d db "d = ", 0
print_abcd:
	push rax

	call endl

	push rax 
	mov rax, str_a
	call print_string_without_endl
	pop rax
	call print_number
	call endl

	mov rax, str_b
	call print_string_without_endl
	mov rax, rbx
	call print_number
	call endl

	mov rax, str_c
	call print_string_without_endl
	mov rax, rcx
	call print_number
	call endl

	mov rax, str_d
	call print_string_without_endl
	mov rax, rdx
	call print_number
	call endl

	call endl
	pop rax
	ret


;|input :
;rax = string
section '.print_string' executable
print_string:
	push_abcd

	mov rcx, rax
	call strlen
	mov rdx, rax
	mov rax, 4
	mov rbx, 1
	int 0x80

	call endl

	pop_dcba

	ret


section '.print_string_without_endl'
;| input 
;	rax = string
print_string_without_endl:
	push_abcd

	mov rcx, rax
	call strlen
	mov rdx, rax
	mov rax, 4
	mov rbx, 1
	int 0x80

	pop_dcba

	ret


section '.endl' executable
endl:
	push rax
	mov rax, 0xA
	call print_char
	pop rax

	ret


section '.print_char' executable
;|input:
;	rax = char
print_char:
	push_abcd
	mov [bss_char], al

	mov rax, 4
	mov rbx, 1
	mov rcx, bss_char
	mov rdx, 1
	int 0x80

	pop_dcba
	ret


section '.print_bytes' executable
;|input:
;	rax = array
;	rbx = size
print_bytes:
	push_abc
	mov rcx, rax
	xor rax,rax
	.next_iter:
		cmp rbx, 0
		je .close
		mov al, [rcx]
		inc rcx
		call print_number
		dec rbx
		mov al, ' '
		call print_char 
		jmp .next_iter
	.close:
		pop_cba
		ret
