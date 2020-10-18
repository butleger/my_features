format ELF64

public number_to_string
public string_to_number
public reverse_string
public strlen

include "macro.m"
include "io.inc"

section '.strlen' executable
; in:
;	rax = string
; out: 
;	rax = number
strlen:
	push rbx
	xor rbx, rbx; rbx - counter
	.next_iter:
		cmp byte [rax + rbx], 0 ; if str[rax + rbx] = '\0'
		je .return
		inc rbx
		jmp .next_iter

	.return:
		mov rax, rbx
		pop rbx
		ret


; in:
;	rax = number
;	rbx = string(buffer for result)
; out:
;	rax = string(result)
section '.number_to_string' executable
number_to_string:
	push_bcd
	xor rcx, rcx; rcx is counter(how many digits will be here)
	mov rdi, 10

	.next_iter:
		div rdi; rax = rax / rdi; rdx = rax / rdi
		; divided by 10 in every loop and push all in stack
		cmp rdx, 0
 		jne .continue
		cmp rax, 0
		jne .continue
		jmp .making_string; if number / 10 = 0 and number % 10 = 0
		.continue:
			push rdx; push digit in stack
			inc rcx
		jmp .next_iter

	.making_string:
		mov rax, rbx
		xor rbx, rbx; new counter 

		.making_string_next_iter:
			cmp rcx, rbx; if amount of digits = new counter
			je .return
			pop rdx; get last digit from stack
			add rdx, '0'
			mov byte [rax + rbx], dl; write char in buffer
			inc rbx
			jmp .making_string_next_iter

	.return:
		mov byte [rax + rbx], 0 ; add '\0' at the end
		pop_dcb
		ret


; in: 
;	rax = string
; out:
;	rax = string
section '.reverse_string' executable
reverse_string:
	push_bcd

	mov rbx, rax; rbx = string 
	call strlen; rax = length
	mov rcx, rax
	mov rax, rbx
	mov rbx, rcx
	xor rcx, rcx; rcx = 0
	dec rbx; size - 1

	.next_iter:
		cmp rbx, rcx
		je .return 
		dec rbx;
		cmp rbx, rcx; if rbx != rcx or rbx - 1!=rcx (because of odd lenght)
		je .return 
		inc rbx
		
		; memory swap
		push rdx
		mov rsi, rcx 
			mov dl, byte [rax + rsi]
			mov cl, byte [rax + rbx] 
			mov byte [rax + rbx], dl
			mov byte [rax + rsi], cl
		mov rcx, rsi
		pop rdx
		
		inc rcx; counter++
		dec rbx; size-- (they go to the center from both directions)
		jmp .next_iter 

	.return:
		pop_dcb
		ret  


section '.string_to_number' executable
; in:
;	rax = string
; out:
;	rax = number
string_to_number:
	push_bcd
	
	mov rcx, rax
	xor rax, rax; here will be chars
	xor rbx, rbx; counter
	xor rdx, rdx; result
	.next_iter:
		cmp [rcx + rbx], byte 0 ; if this is '\0'
		je .close
		mov al, [rcx + rbx]; temp = str[rcx + rbx] - '0'
		sub al, '0'
		imul rdx, 10; number *= 10
		add dl, al; number += temp
		inc rbx
		jmp .next_iter
	.close:
		mov rax, rdx
		pop_dcb
		ret

