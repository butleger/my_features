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
	_buffer_size equ 22; used in input_number
	_buffer_for_number rb _buffer_size; used in input_number 
	bss_char rb 1; used in print_char


section '.input_number' executable
; out:
;	rax = number
input_number:
	push rbx
	mov rax, _buffer_for_number
	mov rbx, _buffer_size
	call input_string; rax = string
	call strlen
	mov rbx, _buffer_for_number
	mov [rbx + rax - 1],byte 0 ; add '\0' at the end
	mov rax, _buffer_for_number; rax = string
	call string_to_number; rax = string_to_number(string)
	pop rbx
	ret


section '.input_string' executable
; in:
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
; in:
;	rax = string(format)
;	stack = values
; this function now is not working
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
; in:
;	rax = number
print_number:
	push_abcd

	xor rcx, rcx

	.next_iter:
		mov rbx, 10
		xor rdx, rdx
		div rbx; rax /= 10, rdx %= 10
		add rdx, '0'
		push rdx; all digits go to stack
		inc rcx
		cmp rax, 0 ; if there is no more digits
		je .print_iter
		jmp .next_iter
	
	.print_iter:
		cmp rcx, 0
		je .return
		pop rax; get digit from stack
		call print_char; and write it
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


; in:
;	rax = string
section '.print_string' executable
print_string:
	push_abcd

	mov rcx, rax
	call strlen
	mov rdx, rax
	mov rax, 4; read interrupt
	mov rbx, 1; STD_OUT
	int 0x80
	call endl; end

	pop_dcba
	ret


section '.print_string_without_endl'
; in:
;	rax = string
print_string_without_endl:
	push_abcd

	mov rcx, rax
	call strlen
	mov rdx, rax
	mov rax, 4; write interruption
	mov rbx, 1; STD_OUT
	int 0x80

	pop_dcba
	ret


section '.endl' executable
endl:
	push rax
	mov rax, 0xA; 0xA - '\n'
	call print_char
	pop rax
	ret


section '.print_char' executable
; in:
;	rax = char
print_char:
	push_abcd
	mov [bss_char], al

	mov rax, 4; write interrupt
	mov rbx, 1; STD_OUT
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
		cmp rbx, 0 ; if counter = 0
		je .close
		mov al, [rcx]
		inc rcx
		call print_number; print number from array
		dec rbx
		mov al, ' '; print space
		call print_char 
		jmp .next_iter
	.close:
		pop_cba
		ret
