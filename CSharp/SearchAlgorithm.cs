// Not working

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp
{

	public class BoyerMooreAlgo
	{
		private int[] _suffixes;
		private int[] bmGs; // Good suffix shift
		private int[] bmBc; // Bad character

		void preBmBc(char[] x, int m, ref int[] bmBc)
		{
			int i;
			for (i = 0; i < x.Length; ++i)
				bmBc[i] = m;
			for (i = 0; i < m - 1; ++i)
				bmBc[x[i]] = m - i - 1;
		}

		void suffixes(char[] x, int m, int[] suff)
		{
			int f = 0;
			int g, i;

			suff[m - 1] = m;
			g = m - 1;
			for (i = m - 2; i >= 0; --i)
			{
				if (i > g && suff[i + m - 1 - f] < i - g)
					suff[i] = suff[i + m - 1 - f];
				else
				{
					if (i < g)
						g = i;
					f = i;
					while (g >= 0 && x[g] == x[g + m - 1 - f])
						--g;
					suff[i] = f - g;
				}
			}
		}

		void preBmGs(char[] x, int m, ref int[] bmGs)
		{
			int i, j, suff[XSIZE];

			suffixes(x, m, suff);

			for (i = 0; i < m; ++i)
				bmGs[i] = m;
			j = 0;
			for (i = m - 1; i >= 0; --i)
				if (suff[i] == i + 1)
					for (; j < m - 1 - i; ++j)
						if (bmGs[j] == m)
							bmGs[j] = m - 1 - i;
			for (i = 0; i <= m - 2; ++i)
				bmGs[m - 1 - suff[i]] = m - 1 - i;
		}

		public void BoyerMoore(string source, string search)
		{
			bmGs = new int[source.Length + 1];
		}

		void BoyerMoore(char[] x, int m, char[] y, int n)
		{
			int i, j;
			int[] bmGs[XSIZE], bmBc[ASIZE];

			/* Preprocessing */
			preBmGs(x, m, ref bmGs);
			preBmBc(x, m, ref bmBc);

			/* Searching */
			j = 0;
			while (j <= n - m)
			{
				for (i = m - 1; i >= 0 && x[i] == y[i + j]; --i) ;
				if (i < 0)
				{
					OUTPUT(j);
					j += bmGs[0];
				}
				else
					j += MAX(bmGs[i], bmBc[y[i + j]] - m + 1 + i);
			}
		}



		void ApostolicoGiancarlo(char* x, int m, char* y, int n)
		{
			int i, j, k, s, shift,
				bmGs[XSIZE], skip[XSIZE], suff[XSIZE], bmBc[ASIZE];

			/* Preprocessing */
			preBmGs(x, m, bmGs, suff);
			preBmBc(x, m, bmBc);
			memset(skip, 0, m * sizeof(int));

			/* Searching */
			j = 0;
			while (j <= n - m)
			{
				i = m - 1;
				while (i >= 0)
				{
					k = skip[i];
					s = suff[i];
					if (k > 0)
						if (k > s)
						{
							if (i + 1 == s)
								i = (-1);
							else
								i -= s;
							break;
						}
						else
						{
							i -= k;
							if (k < s)
								break;
						}
					else
					{
						if (x[i] == y[i + j])
							--i;
						else
							break;
					}
				}
				if (i < 0)
				{
					OUTPUT(j);
					skip[m - 1] = m;
					shift = bmGs[0];
				}
				else
				{
					skip[m - 1] = m - 1 - i;
					shift = MAX(bmGs[i], bmBc[y[i + j]] - m + 1 + i);
				}
				j += shift;
				memcpy(skip, skip + shift, (m - shift) * sizeof(int));
				memset(skip + m - shift, 0, shift * sizeof(int));
			}
		}
	}
}
