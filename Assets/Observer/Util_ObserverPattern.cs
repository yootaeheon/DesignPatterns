using System.Collections.Generic;

// V1. 인터페이스를 이용한 옵저버 패턴
// V2. 제네릭, 델리게이트 사용한 옵저버 패턴

// 옵저버 패턴 :
// 주시 대상(Subject)이 되는 객체가 자신의 데이터 변경 시
// 등록된 관찰자(Observer)들에게 알려주는 디자인 패턴.
// 이를 통해 주기적으로 확인하지 않아도 데이터 변화에 대응할 수 있으므로 최적화에 유용

// 주의점 : 
// 더 이상 사용하지 않는 객체는 구독을 해지하기
// 옵저버가 많아질수록 무거워짐
// 구조 복잡도 증가
namespace Util_ObserverPattern
{
    /// <summary>
    /// Observer(관찰자) : 알림을 받았을 때 각자 행동을 하는 주체;
    /// 실제로 로직을 구현하는 클래스에서 인터페이스를 상속받아 구현
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        /// 알림을 받았을 때, 수행할 로직을 구현하는 메서드
        /// </summary>
        public void OnNotify();
    }

    /// <summary>
    /// Subject(주시 대상) : 데이터를 가지고 있으며, 데이터 변동 시 알림을 전송;
    /// </summary>
    public class Subject
    {
        private List<IObserver> _observers = new();

        /// <summary>
        /// 구독 메서드
        /// </summary>
        /// <param name="observer"></param>
        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
        }

        /// <summary>
        /// 구독 해제 메서드
        /// </summary>
        /// <param name="observer"></param>
        public void Unsubscribe(IObserver observer)
        {
            _observers.Remove(observer);
        }

        /// <summary>
        /// 전체 구독 해제 메서드
        /// </summary>
        /// <param name="observer"></param>
        public void UnsubscribeAll(IObserver observer)
        {
            _observers.RemoveAll(x => true);
        }

        /// <summary>
        /// 알림을 전송하는 메서드;
        /// 즉, 구독자들에게 행동 실시! 하는 메서드
        /// </summary>
        public void Notify()
        {
            foreach (var obs in _observers)
            {
                obs.OnNotify();
            }
        }
    }

    /// <summary>
    /// 제네릭을 사용하여 옵저버 객체를 저장해놓는 것이 아닌 함수를 지니는 클래스
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObservableProperty<T>
    {
        public delegate void ObserverMethod();
        private ObserverMethod _onNotify;

        private T _value;
        public T Value { get { return _value; } set { _value = value; Notify(); } } // set 될 때 델리게이트에 지정된 함수 실행

        /// <summary>
        /// 알릴 전송 대신에 함수를 실행
        /// </summary>
        public void Notify()
        {
            _onNotify?.Invoke();
        }
        
        /// <summary>
        /// 메서드를 구독
        /// </summary>
        /// <param name="method"></param>
        public void Subscribe(ObserverMethod method)
        {
            _onNotify += method;
        }

        /// <summary>
        /// 메서드 구독 해제
        /// </summary>
        /// <param name="method"></param>
        public void Unsubscribe(ObserverMethod method)
        {
            _onNotify -= method;
        }

        /// <summary>
        /// 모든 구독 해제
        /// </summary>
        public void UnsubscribeAll()
        {
            _onNotify = null;
        }
    }
}