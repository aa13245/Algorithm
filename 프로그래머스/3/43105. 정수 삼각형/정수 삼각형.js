function solution(triangle) {
    // 노드별 최댓값 저장 캐시
    var max = new Array(triangle.length);
    for (i = 0; i < max.length; i++){
        max[i] = new Array(triangle[i].length);
    }
    max[0][0] = triangle[0][0];
    // 맨 아랫층 제외 모든 노드에 대해서
    for (i = 0; i < triangle.length - 1; i++){
        for (j = 0; j < triangle[i].length; j++){
            // 아래 양옆 노드 연산
            max[i + 1][j] = Math.max(max[i + 1][j] ? max[i + 1][j] : 0, max[i][j] + triangle[i + 1][j]);
            max[i + 1][j + 1] = Math.max(max[i + 1][j + 1] ? max[i + 1][j + 1] : 0, max[i][j] + triangle[i + 1][j + 1]);
        }
    }    
    var answer = Math.max(...max[max.length - 1]);
    return answer;
}