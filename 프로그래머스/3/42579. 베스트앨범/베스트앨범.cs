using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] solution(string[] genres, int[] plays) {
        // 장르별 차트 - 우선순위 : 1. 높은 재생 횟수, 2. 낮은 고유 번호
        var charts = new Dictionary<string, SortedSet<KeyValuePair<int, int>>>(); // key : 고유번호, value : 재생횟수
        // 장르별 총 재생 횟수
        Dictionary<string, int> genrePlays = new Dictionary<string, int>();
        // 초기화
        foreach (string genre in genres)
        {
            charts[genre] = new SortedSet<KeyValuePair<int, int>>(new MusicCompare());
            genrePlays[genre] = 0;
        }
        // 차트 정리
        for (int i = 0; i < genres.Length; i++)
        {
            charts[genres[i]].Add(new KeyValuePair<int, int>(i, plays[i]));
            genrePlays[genres[i]] += plays[i];
        }
        // 장르 곡 수 순위
        var genreRank = new SortedSet<KeyValuePair<string, int>>(new GenreCompare()); // key : 장르, value : 곡 수
        foreach (string genre in charts.Keys)
        {
            genreRank.Add(new KeyValuePair<string, int>(genre, genrePlays[genre]));
        }
        // 앨범 생성
        List<int> album = new List<int>();
        foreach (KeyValuePair<string, int> genre in genreRank)
        {
            int first = charts[genre.Key].First().Key;
            album.Add(first);
            if (charts[genre.Key].Count > 1)
            {
                int second = charts[genre.Key].ElementAt(1).Key;
                album.Add(second);
            }
        }
        int[] answer = album.ToArray();
        return answer;
    }
    public class MusicCompare : IComparer<KeyValuePair<int, int>> {
        public int Compare(KeyValuePair<int, int> x, KeyValuePair<int, int> y)
        {
            int compare = y.Value.CompareTo(x.Value);
            if (compare == 0) return x.Key.CompareTo(y.Key);
            else return compare;
        }
    }
    public class GenreCompare : IComparer<KeyValuePair<string, int>> {
        public int Compare(KeyValuePair<string, int> x, KeyValuePair<string, int> y)
        {
            return y.Value.CompareTo(x.Value);
        }
    }
}