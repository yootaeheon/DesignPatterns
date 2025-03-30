using System.Collections.Generic;

// V1. �������̽��� �̿��� ������ ����
// V2. ���׸�, ��������Ʈ ����� ������ ����

// ������ ���� :
// �ֽ� ���(Subject)�� �Ǵ� ��ü�� �ڽ��� ������ ���� ��
// ��ϵ� ������(Observer)�鿡�� �˷��ִ� ������ ����.
// �̸� ���� �ֱ������� Ȯ������ �ʾƵ� ������ ��ȭ�� ������ �� �����Ƿ� ����ȭ�� ����

// ������ : 
// �� �̻� ������� �ʴ� ��ü�� ������ �����ϱ�
// �������� ���������� ���ſ���
// ���� ���⵵ ����
namespace Util_ObserverPattern
{
    /// <summary>
    /// Observer(������) : �˸��� �޾��� �� ���� �ൿ�� �ϴ� ��ü;
    /// ������ ������ �����ϴ� Ŭ�������� �������̽��� ��ӹ޾� ����
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        /// �˸��� �޾��� ��, ������ ������ �����ϴ� �޼���
        /// </summary>
        public void OnNotify();
    }

    /// <summary>
    /// Subject(�ֽ� ���) : �����͸� ������ ������, ������ ���� �� �˸��� ����;
    /// </summary>
    public class Subject
    {
        private List<IObserver> _observers = new();

        /// <summary>
        /// ���� �޼���
        /// </summary>
        /// <param name="observer"></param>
        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
        }

        /// <summary>
        /// ���� ���� �޼���
        /// </summary>
        /// <param name="observer"></param>
        public void Unsubscribe(IObserver observer)
        {
            _observers.Remove(observer);
        }

        /// <summary>
        /// ��ü ���� ���� �޼���
        /// </summary>
        /// <param name="observer"></param>
        public void UnsubscribeAll(IObserver observer)
        {
            _observers.RemoveAll(x => true);
        }

        /// <summary>
        /// �˸��� �����ϴ� �޼���;
        /// ��, �����ڵ鿡�� �ൿ �ǽ�! �ϴ� �޼���
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
    /// ���׸��� ����Ͽ� ������ ��ü�� �����س��� ���� �ƴ� �Լ��� ���ϴ� Ŭ����
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObservableProperty<T>
    {
        public delegate void ObserverMethod();
        private ObserverMethod _onNotify;

        private T _value;
        public T Value { get { return _value; } set { _value = value; Notify(); } } // set �� �� ��������Ʈ�� ������ �Լ� ����

        /// <summary>
        /// �˸� ���� ��ſ� �Լ��� ����
        /// </summary>
        public void Notify()
        {
            _onNotify?.Invoke();
        }
        
        /// <summary>
        /// �޼��带 ����
        /// </summary>
        /// <param name="method"></param>
        public void Subscribe(ObserverMethod method)
        {
            _onNotify += method;
        }

        /// <summary>
        /// �޼��� ���� ����
        /// </summary>
        /// <param name="method"></param>
        public void Unsubscribe(ObserverMethod method)
        {
            _onNotify -= method;
        }

        /// <summary>
        /// ��� ���� ����
        /// </summary>
        public void UnsubscribeAll()
        {
            _onNotify = null;
        }
    }
}