#include <windows.h>
#include <tchar.h>
#include <string>
#include <strsafe.h>
#include <atlstr.h>
#include "resource.h"
#include <gdiplus.h>



// 循环执行次数，这个数字越大花屏时间约长
#define NUM 300
LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);

// 回调函数
// 对屏幕进行花屏操作
BOOL CALLBACK MonitorEnumProc(HMONITOR hMonitor, HDC hdcMonitor, LPRECT lprcMonitor, LPARAM dwData) {
	static int iKeep[NUM][4];
	HDC        hdcScr, hdcMem;
	int        cx, cy;
	HBITMAP    hBitmap;
	HWND       hwnd;
	int        i, j, x1, y1, x2, y2;

	if (LockWindowUpdate(hwnd = GetDesktopWindow()))
	{
		hdcScr = GetDCEx(hwnd, NULL, DCX_CACHE | DCX_LOCKWINDOWUPDATE);
		hdcMem = CreateCompatibleDC(hdcScr);
		cx = GetSystemMetrics(SM_CXSCREEN) / 3;
		cy = GetSystemMetrics(SM_CYSCREEN) / 3;
		hBitmap = CreateCompatibleBitmap(hdcScr, cx, cy);



		srand((int)GetCurrentTime());

		for (i = 0; i < 2; i++)
			for (j = 0; j < NUM; j++)
			{
				LockWindowUpdate(hwnd = GetDesktopWindow());
				if (i == 0)
				{
					iKeep[j][0] = x1 = cx * (rand() % 10);
					iKeep[j][1] = y1 = cy * (rand() % 10);
					iKeep[j][2] = x2 = cx * (rand() % 10);
					iKeep[j][3] = y2 = cy * (rand() % 10);
				}
				else
				{
					x1 = iKeep[NUM - 1 - j][0];
					y1 = iKeep[NUM - 1 - j][1];
					x2 = iKeep[NUM - 1 - j][2];
					y2 = iKeep[NUM - 1 - j][3];
				}
				BitBlt(hdcMem, 0, 0, cx, cy, hdcScr, x1, y1, SRCCOPY);
				BitBlt(hdcScr, x1, y1, cx, cy, hdcScr, x2, y2, SRCCOPY);
				BitBlt(hdcScr, x2, y2, cx, cy, hdcMem, 0, 0, SRCCOPY);

			}

		DeleteDC(hdcMem);
		ReleaseDC(hwnd, hdcScr);
		DeleteObject(hBitmap);
	}
	LockWindowUpdate(0);
	return TRUE;
}

// 花屏程序，使用户的屏幕短暂的花屏
int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, PSTR szCmdLine, int iCmdShow)
{
	HDC hdc;
	hdc = GetDC(NULL);

	// 枚举显示器，调用回调函数对每个显示器进行同样的操作
	EnumDisplayMonitors(hdc, NULL, MonitorEnumProc, 0);
	ReleaseDC(NULL, hdc);
}

