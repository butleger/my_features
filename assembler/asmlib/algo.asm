format ELF64

public bubble_sort

include "io.inc" 
include "macro.m"

section '.bubble_sort' executable
; |input:
;	rax = array(bytes)
;	rbx = size
; this function will sort massive in his own buffer
; |output:
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
