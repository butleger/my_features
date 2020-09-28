format ELF64

public bubble_sort
public dw_rand
public q_srand

include "io.inc" 
include "macro.m"


section '.data' writable
seed dq 1; usnig in q_srand and in q_rand	
_next dq 1; using in dw_rand


section '.q_srand' executable
; in:
;	rax = seed(quad)
q_srand:
	mov [seed], rax
	ret


section '.dw_rand' executable
; out:
;	rax = random number(double word)
dw_rand:
	push rbx
	push rdx
	xor rbx, rbx
	mov rax, [_next]
	mov rbx, 1103515245
	mul rbx
	mov rbx, 12345
	add rax, rbx
	mov [_next], rax
	xor rdx, rdx
	mov rbx, 65536
	div rbx
	mov rbx, 32568
	xor rdx, rdx
	div rbx
	mov rax, rdx
	xor rdx, rdx
	pop rdx
	pop rbx
	ret


section '.bubble_sort' executable
; in:
;	rax = array(bytes)
;	rbx = size
; this function will sort massive in his own buffer
; out:
;	rax = sorted array
bubble_sort:
	push_abcd
	
	;xor rbx, rbx
	dec rbx; to reject overflow
	xor rcx, rcx; i
	xor rdx, rdx; j 
	.next_iter:
		cmp rcx, rbx
		je .close
		.inner_loop:
			cmp rdx, rbx; if rdx != size
			je .end_inner_loop
				
			push rcx
			mov cl, [rax + rdx]
			cmp cl,byte [rax + rdx + 1]; if a[i] > a[i + 1]
			jg .swap
			jmp .no_swap
			
			;go this way if arr[i] > arr[i + 1]	
			.swap:
				push rbx
				push rcx
				mov cl, [rax + rdx]
				mov bl, [rax + rdx + 1]
				mov [rax + rdx], bl
				mov [rax + rdx + 1], cl
				pop rcx
				pop rbx
			.no_swap:
				pop rcx
				inc rdx; j++		
				jmp .inner_loop
		.end_inner_loop:
			inc rcx; i++
			xor rdx, rdx; j = 0
			jmp .next_iter
	.close:
		pop_dcba
		ret
