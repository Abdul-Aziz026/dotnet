#include <iostream>
#include <algorith>
using namespace std;


int main() {
    int n; cin >> n;
    vector <int> a(n);
    for (int i = 0; i < n; ++i) {
        cin >> a[i];
    }
    sort(a.begin(), a.end());
    for (int i: a) {
        cout << i <<  " ";
    }
    cout << endl;
    return 0;
}